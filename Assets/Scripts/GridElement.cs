using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] 
    private BlockManager RandomBlock;
    [SerializeField] 
    private GridManager GridManager;
    [SerializeField] 
    private Timer Timer;
    [SerializeField] 
    private Transform attackPoint;

    [HideInInspector]
    public bool isEmptyGrid;

    private int blockIndex;
    private Image gridImage;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(FillGrid);
        gridImage = GetComponent<Image>();
    }

    private void Start()
    {
        isEmptyGrid = true;
    }

    /// <summary>
    /// Mengisi grid dengan blok
    /// </summary>
    public void FillGrid()
    {
        //Memastikan bahwa grid yang diklik merupakan grid kosong
        if (isEmptyGrid)
        {
            //Jika blok menyerang
            if (GridManager.isAttacking)
            {
                //Maka pemain kalah
                GridManager.LoseCondition();
            }
            else
            {
                //Mengganti sprite grid menjadi sprite random
                gridImage.sprite = RandomBlock.blockSprites[RandomBlock.randomIndex];

                //Membuat grid menjadi tidak bisa diklik lagi
                isEmptyGrid = false;

                //Mengubah tag menjadi filled grid
                gameObject.tag = "Filled Grid";

                //Menyimpan nomor random index ke block index dan memanggil fungsi untuk menyimpan block ke dalam list sesuai dengan tipe block
                blockIndex = RandomBlock.randomIndex;
                GridManager.AddGridElementList(gridImage, blockIndex);

                //Update UI score sesuai dengan nilai dari sprite yang diletakkan
                RandomBlock.UpdateScore();

                //Mengatur ulang time ke durasi awal
                Timer.time = Timer.duration;

                //Mengacak lagi slot random block
                RandomBlock.RandomBlockSprite();

                //Menampilkan attack zone terbaru
                RandomBlock.ShowAttackZone();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Mengubah posisi attack point/attack zone ke posisi grid dan menampilkan attack zone sesuai dengan blok yang muncul
        attackPoint.position = transform.position;
        RandomBlock.ShowAttackZone();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Menyembunyikan attack zone sesuai dengan blok yang muncul dan mengatur kalau blok tidak menyerang apapun
        RandomBlock.HideAttackZone();
        GridManager.isAttacking = false;
    }
}
