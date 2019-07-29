using System.Web.Http;
using WebActivatorEx;
using LibraryManagerWebApiForWebChat;
using Swashbuckle.Application;
using System.Collections.Concurrent;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Xml;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace LibraryManagerWebApiForWebChat
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                       
                        c.SingleApiVersion("v1", "LibraryManagerWebApiForWebChat");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));//汉化Swagger两步：第一步

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.InjectJavaScript(thisAssembly, "LibraryManagerWebApiForWebChat.SwaggerUI.hanhua.js");
                    });
        }

        //添加XML解析
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/LibraryManagerWebApiForWebChat.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        public class CachingSwaggerProvider : Swashbuckle.Swagger.ISwaggerProvider
        {
            private static ConcurrentDictionary<string, SwaggerDocument> _cache =
           new ConcurrentDictionary<string, SwaggerDocument>();

            private readonly ISwaggerProvider _swaggerProvider;

            public SwaggerDocument GetSwagger(string rootUrl, string apiVersion)
            {
                var cacheKey = string.Format("{0}_{1}", rootUrl, apiVersion);
                SwaggerDocument srcDoc = null;
                //只读取一次
                if (!_cache.TryGetValue(cacheKey, out srcDoc))
                {
                    srcDoc = _swaggerProvider.GetSwagger(rootUrl, apiVersion);

                    srcDoc.vendorExtensions = new Dictionary<string, object> { { "ControllerDesc", GetControllerDesc() } };
                    _cache.TryAdd(cacheKey, srcDoc);
                }
                return srcDoc;
            }

            public CachingSwaggerProvider(ISwaggerProvider swaggerProvider)
            {
                _swaggerProvider = swaggerProvider;
            }

            /// <summary>
            /// 从API文档中读取控制器描述
            /// </summary>
            /// <returns>所有控制器描述</returns>
            public static ConcurrentDictionary<string, string> GetControllerDesc()
            {
                string xmlpath = string.Format("{0}/bin/{1}.XML", System.AppDomain.CurrentDomain.BaseDirectory, typeof(SwaggerConfig).Assembly.GetName().Name);
                ConcurrentDictionary<string, string> controllerDescDict = new ConcurrentDictionary<string, string>();
                if (File.Exists(xmlpath))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(xmlpath);
                    string type = string.Empty, path = string.Empty, controllerName = string.Empty;

                    string[] arrPath;
                    int length = -1, cCount = "Controller".Length;
                    XmlNode summaryNode = null;
                    foreach (XmlNode node in xmldoc.SelectNodes("//member"))
                    {
                        type = node.Attributes["name"].Value;
                        if (type.StartsWith("T:"))
                        {
                            //控制器
                            arrPath = type.Split('.');
                            length = arrPath.Length;
                            controllerName = arrPath[length - 1];
                            if (controllerName.EndsWith("Controller"))
                            {
                                //获取控制器注释
                                summaryNode = node.SelectSingleNode("summary");
                                string key = controllerName.Remove(controllerName.Length - cCount, cCount);
                                if (summaryNode != null && !string.IsNullOrEmpty(summaryNode.InnerText) && !controllerDescDict.ContainsKey(key))
                                {
                                    controllerDescDict.TryAdd(key, summaryNode.InnerText.Trim());
                                }
                            }
                        }
                    }
                }
                return controllerDescDict;
            }
        }

    }
}
