using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Image blockRandomImage;
    [SerializeField]
    private GameObject bishopAtkZone, rockAtkZone, dragonAtkZone, knightAtkZone;
    [SerializeField]
    private int[] blockValues;

    [HideInInspector]
    public int randomIndex;

    public Sprite[] blockSprites;

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

    /// <summary>
    /// Mengacak blok sprite dan memanggil fungsi ChangeBlockSprite dan ChangeScore
    /// </summary>
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

    /// <summary>
    /// Update score ke UI
    /// </summary>
    public void UpdateScore()
    {
        scoreText.text = scoreValue.ToString(); 
    }

    /// <summary>
    /// Menampilkan Attack Zone sesuai dengan blok yang muncul
    /// </summary>
    public void ShowAttackZone()
    {
        HideAttackZone();

        switch (randomIndex)
        {
            case 0:
                bishopAtkZone.SetActive(true); 
                break;
            case 1:
                rockAtkZone.SetActive(true); 
                break;
            case 2:
                dragonAtkZone.SetActive(true); 
                break;
            case 3:
                knightAtkZone.SetActive(true); 
                break;
        }
    }

    /// <summary>
    /// Menyembunyikan Attack Zone
    /// </summary>
    public void HideAttackZone()
    {
        bishopAtkZone.SetActive(false);
        rockAtkZone.SetActive(false);
        dragonAtkZone.SetActive(false);
        knightAtkZone.SetActive(false);
    }
}
