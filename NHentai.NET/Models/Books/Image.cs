using System.Text.Json.Serialization;
using NHentai.NET.Converters;

namespace NHentai.NET.Models.Books
{
    /// <summary>
    /// Represents an image page for a <see cref="Book"/>.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// The image file extension.
        /// </summary>
        [JsonPropertyName("t")]
        [JsonConverter(typeof(FileTypeConverter))]
        public FileType Type { get; set; }
        
        /// <summary>
        /// The image pixel width.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }


        /// <summary>
        /// The image pixel height.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }
    }
    
    /// <summary>
    /// Represents a cover image for a <see cref="Book"/>.
    /// </summary>
    public class Cover : Image
    {
    }
    
    /// <summary>
    /// Represents a thumbnail image for a <see cref="Book"/>.
    /// </summary>
    public class Thumbnail : Image
    {
    }
    
    /// <summary>
    /// Represents all possible file extensions.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// A jpg file type.
        /// </summary>
        Jpg,
        
        /// <summary>
        /// A png file type.
        /// </summary>
        Png,
        
        /// <summary>
        /// A gif file type.
        /// </summary>
        Gif
    }
}