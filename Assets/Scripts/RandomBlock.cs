using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomBlock : MonoBehaviour
{
    public Sprite[] blockSprites;
    public int[] blockValues;
    public TextMeshProUGUI scoreText;
    public Image blockRandomImage;
    public int randomIndex;

    private int scoreValue;

    private void Start()
    {
        RandomBlockSprite();
    }

    private Sprite GetRandomBlockSprite(int randomIndex)
    {
        return blockSprites[randomIndex];
    }

    private int GetRandomBlockValue(int randomIndex)
    {
        return blockValues[randomIndex];
    }

    public void RandomBlockSprite()
    {
        randomIndex = Random.Range(0, blockSprites.Length);

        ChangeBlockSprite();
        ChangeScore();
    }

    private void ChangeBlockSprite()
    {
        blockRandomImage.sprite = GetRandomBlockSprite(randomIndex);
    }

    private void ChangeScore()
    {
        scoreValue += GetRandomBlockValue(randomIndex);
    }

    public void UpdateScore()
    {
        scoreText.text = scoreValue.ToString(); 
    }
}
