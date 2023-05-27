using UnityEngine;
using UnityEngine.UI;

public class GridElement : MonoBehaviour
{
    public RandomBlock RandomBlock;
    public GridManager gridManager;
    public Timer Timer;
    public int blockIndex;
    public bool canChange;

    private Image gridImage;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeGridSprite);
        gridImage = GetComponent<Image>();
    }

    private void Start()
    {
        canChange = true;
    }

    public void ChangeGridSprite()
    {
        if (canChange)
        {
            //Mengganti sprite grid menjadi sprite random
            gridImage.sprite = RandomBlock.blockSprites[RandomBlock.randomIndex];

            //Mengatur ulang time ke durasi awal
            Timer.time = Timer.duration;

            //Update UI score sesuai dengan nilai dari sprite yang diletakkan
            RandomBlock.UpdateScore();

            //Mengubah grid menjadi tidak bisa diklik lagi
            canChange = false;

            //Menyimpan nomor random index ke block index dan memanggil fungsi untuk menyimpan block ke dalam list sesuai dengan tipe block
            blockIndex = RandomBlock.randomIndex;
            gridManager.AddGridElementList(gridImage, blockIndex);

            //Mengacak lagi slot random block
            RandomBlock.RandomBlockSprite();
        }
    }
}
