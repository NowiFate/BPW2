using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public static BlockScript Instance;
    public GameObject PlacedBlockPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void SpawnBlock()
    {
        PlacedBlockPrefab.transform.position = this.transform.position;
        GameObject a = Instantiate(PlacedBlockPrefab) as GameObject;
        PlayerControlls.Instance.blocksNumber -= 1;
    }
}
