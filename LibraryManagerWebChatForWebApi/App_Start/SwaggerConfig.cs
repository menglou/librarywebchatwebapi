using System.Web.Http;
using WebActivatorEx;
using LibraryManagerWebChatForWebApi;
using Swashbuckle.Application;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Swashbuckle.Swagger;
using System;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace LibraryManagerWebChatForWebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                       
                        c.SingleApiVersion("v1.0.0", "ͼ��ݹ���С�����Weapi�ĵ��ӿ�");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.UseFullTypeNameInSchemaIds();
                        c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));

                    })
                .EnableSwaggerUi(c =>
                    {
                        //·��������Ŀ�����ռ�.�ļ�������.js�ļ�����
                        c.InjectJavaScript(thisAssembly, "LibraryManagerWebChatForWebApi.SwaggerUI.hanhua.js");
                    });
        }

        //���XML����
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/LibraryManagerWebChatForWebApi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }


        public class CachingSwaggerProvider : Swashbuckle.Swagger.ISwaggerProvider
        {
            private static ConcurrentDictionary<string, SwaggerDocument> _cache =
                new ConcurrentDictionary<string, SwaggerDocument>();

            private readonly ISwaggerProvider _swaggerProvider;

            public CachingSwaggerProvider(ISwaggerProvider swaggerProvider)
            {
                _swaggerProvider = swaggerProvider;
            }

            public SwaggerDocument GetSwagger(string rootUrl, string apiVersion)
            {
                var cacheKey = string.Format("{0}_{1}", rootUrl, apiVersion);
                SwaggerDocument srcDoc = null;
                //ֻ��ȡһ��
                if (!_cache.TryGetValue(cacheKey, out srcDoc))
                {
                    srcDoc = _swaggerProvider.GetSwagger(rootUrl, apiVersion);

                    srcDoc.vendorExtensions = new Dictionary<string, object> { { "ControllerDesc", GetControllerDesc() } };
                    _cache.TryAdd(cacheKey, srcDoc);
                }
                return srcDoc;
            }

            /// <summary>
            /// ��API�ĵ��ж�ȡ����������
            /// </summary>
            /// <returns>���п���������</returns>
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
                            //������
                            arrPath = type.Split('.');
                            length = arrPath.Length;
                            controllerName = arrPath[length - 1];
                            if (controllerName.EndsWith("Controller"))
                            {
                                //��ȡ������ע��
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
