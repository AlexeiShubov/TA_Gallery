using UnityEngine;
using UnityEngine.UI;

public class ImageScrollController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject imagePrefab;
    public RectTransform contentTransform;

    private const int maxImages = 4; // Максимальное количество одновременно загружаемых изображений
    private const float imageHeight = 200f; // Высота изображения в скролле
    private const float padding = 10f; // Отступ между изображениями

    private int currentIndex = 0; // Индекс текущего изображения
    private Texture2D[] images; // Массив текстур для хранения загруженных изображений

    private void Start()
    {
        images = new Texture2D[maxImages];

        for (int i = 0; i < maxImages; i++)
        {
            LoadImage(i);
        }
    }

    private void LoadImage(int index)
    {
        // Загрузка изображения с удаленного сервера
        // Для примера, используется случайная текстура
        Texture2D texture = LoadTextureFromServer();

        if (texture != null)
        {
            images[index] = texture;

            // Создание и размещение нового изображения в скролле
            GameObject imageObject = Instantiate(imagePrefab, contentTransform);
            RectTransform imageRectTransform = imageObject.GetComponent<RectTransform>();
            imageRectTransform.anchoredPosition = new Vector2(0, -index * (imageHeight + padding));

            // Назначение текстуры изображению
            RawImage rawImage = imageObject.GetComponent<RawImage>();
            rawImage.texture = texture;
        }
    }

    private Texture2D LoadTextureFromServer()
    {
        // Загрузка и возврат текстуры с удаленного сервера
        // В этом методе должен быть реализован код для загрузки изображений с сервера
        // Возвращаем значение null, так как пример работает со случайными текстурами
        return Texture2D.whiteTexture;
    }

    public void OnScrollValueChanged()
    {
        float normalizedPosition = scrollRect.verticalNormalizedPosition;

        if (normalizedPosition < 0f)
        {
            // Проверка, если достигнут верхний предел скролла
            currentIndex--;

            if (currentIndex >= 0)
            {
                // Прокрутка вверх, загрузка нового изображения и удаление старого
                Destroy(contentTransform.GetChild(maxImages).gameObject);
                LoadImage(currentIndex);
            }
            else
            {
                // Достигнут верхний предел скролла, возвращение на нижний предел
                currentIndex = maxImages - 1;
                scrollRect.verticalNormalizedPosition = 1f;
            }
        }
        else if (normalizedPosition > 1f)
        {
            // Проверка, если достигнут нижний предел скролла
            currentIndex++;

            if (currentIndex < maxImages)
            {
                // Прокрутка вниз, загрузка нового изображения и удаление старого
                Destroy(contentTransform.GetChild(0).gameObject);
                LoadImage(currentIndex);
            }
            else
            {
                // Достигнут нижний предел скролла, возвращение на верхний предел
                currentIndex = 0;
                scrollRect.verticalNormalizedPosition = 0f;
            }
        }
    }
}