using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] 
    private GridManager GridManager;
    [SerializeField]
    private GameObject popUpLose;

    private void OnTriggerEnter(Collider other)
    {
        //Jika trigger mendeteksi tag Filled Grid maka menyerang
        if (other.CompareTag("Filled Grid"))
        {
            GridManager.isAttacking = true;
        }
    }
}
