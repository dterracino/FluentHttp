namespace FluentHttp
{
    using System;
    using System.Net;

    /// <summary>
    /// </summary>
    public class FluentHttpResponse : IFluentHttpResponse
    {
        private readonly IFluentHttpRequest _fluentHttpRequest;

        public FluentHttpResponse(IFluentHttpRequest fluentHttpRequest, HttpWebResponse httpWebResponse)
        {
            ResponseStatus = ResponseStatus.Non;
            _fluentHttpRequest = fluentHttpRequest;

            if (httpWebResponse != null)
            {
                ContentLength = httpWebResponse.ContentLength;
                ContentType = httpWebResponse.ContentType;
                Method = httpWebResponse.Method;
                ResponseUri = httpWebResponse.ResponseUri;
                StatusCode = httpWebResponse.StatusCode;
                StatusDescription = httpWebResponse.StatusDescription;

#if !SILVERLIGHT
                IsMutuallyAuthenticated = httpWebResponse.IsMutuallyAuthenticated;
                CharacterSet = httpWebResponse.CharacterSet;
                ContentEncoding = httpWebResponse.ContentEncoding;
                LastModified = httpWebResponse.LastModified;
                ProtocolVersion = httpWebResponse.ProtocolVersion;
                Server = httpWebResponse.Server;
                Headers = httpWebResponse.Headers;
                Cookies = httpWebResponse.Cookies;
#endif
            }
        }

        /// <summary>
        /// Gets the <see cref="IFluentHttpRequest"/>.
        /// </summary>
        public IFluentHttpRequest Request
        {
            get
            {
                return _fluentHttpRequest;
            }
        }

        /// <summary>
        /// Gets or sets the exception occurred when making a web request.
        /// </summary>
        /// <remarks>
        /// This exception is not meant to be thrown.
        /// </remarks>
        public Exception Exception { get; set; }

        public ResponseStatus ResponseStatus { get; set; }

        // Copied from http web response.
        // TODO: make it readonly.
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public string Method { get; set; }
        public Uri ResponseUri { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }

#if !SILVERLIGHT
        public bool IsMutuallyAuthenticated { get; set; }
        public string CharacterSet { get; set; }
        public string ContentEncoding { get; set; }
        public DateTime LastModified { get; set; }
        public Version ProtocolVersion { get; set; }
        public string Server { get; set; }
        public WebHeaderCollection Headers { get; set; }
        public CookieCollection Cookies { get; set; }
#endif
    }
}