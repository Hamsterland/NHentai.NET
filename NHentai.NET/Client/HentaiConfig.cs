namespace NHentai.NET.Client
{
    /// <summary>
    /// Represents a class of static configuration variables.
    /// </summary>
    public class HentaiConfig
    {
        /// <summary>
        /// The base API url.
        /// </summary>
        public const string ApiRoot = "https://nhentai.net";
        
        /// <summary>
        /// The front page url.
        /// </summary>
        public const string HomePageRoot = "/api/galleries/all?page={0}";
        
        /// <summary>
        /// The base book API url.
        /// </summary>
        public const string BookRoot = "/api/gallery/";
        
        /// <summary>
        /// The base search API url. 
        /// </summary>
        public const string BookSearchRoot = "/api/galleries/search?query={0}&page={1}&sort={2}";
        
        /// <summary>
        /// The base related books API url.
        /// </summary>
        public const string RelatedSearchRoot = "/api/gallery/{0}/related";
        
        /// <summary>
        /// The base tag search API url.
        /// </summary>
        public const string TagSearchRoot = "/api/galleries/tagged?tag_id={0}&page={1}&sort={2}";
        
        /// <summary>
        /// The base image API url.
        /// </summary>
        public const string ImageApiRoot = "https://i.nhentai.net";

        /// <summary>
        /// The base cover image API url.
        /// </summary>
        public const string CoverImageRoot = "https://t.nhentai.net/galleries/{0}/cover.{1}";
        
        /// <summary>
        /// The base image page API url.
        /// </summary>
        public const string PageSearchRoot = "/galleries/{0}/{1}.jpg";
    }
}