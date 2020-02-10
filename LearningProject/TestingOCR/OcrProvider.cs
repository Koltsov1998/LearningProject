using System.Threading.Tasks;
using IronOcr;

namespace TestingOCR
{
    /// <summary>
    /// Класс, который предоставляет доступ к методам из библиотеки IronOCR (Optical Character Recognition)
    /// </summary>
    public class OcrProvider
    {
        /// <summary>
        /// Получить текст из картинки
        /// </summary>
        /// <param name="imageFilePath"></param>
        /// <returns></returns>
        public async Task<string> GetTextFromImage(string imageFilePath)
        {
            return await Task.Run(() =>
            {
                var ocr = new AutoOcr();
                var result = ocr.Read(imageFilePath);
                return result.Text;
            });
        }
    }
}
