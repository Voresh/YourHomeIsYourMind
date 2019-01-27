using UnityEngine;

public static class PillsCreator
{
    public static void CreateAD(Transform position)
    {
        var prefab = Resources.Load("AD");
        Object.Instantiate(prefab, position.transform.position, Quaternion.identity);
    }
    
    public static void CreateTranq(Transform position)
    {
        var prefab = Resources.Load("Tranq");
        Object.Instantiate(prefab, position.transform.position, Quaternion.identity);
    }
}