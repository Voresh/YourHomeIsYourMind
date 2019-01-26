using UnityEngine;

public static class RaycastExtensions
{
    public static T GetComponentUnderCoursor<T>(this Camera inputCamera) where T: class
    {
        RaycastHit hit;
        return Physics.Raycast(inputCamera.ScreenPointToRay(Input.mousePosition), out hit)
            ? hit.transform.GetComponent<T>()
            : null;
    }
    
    public static T GetComponentUnderCoursor2D<T>(this Camera inputCamera) where T: class
    {
        var hit = Physics2D.Raycast(inputCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return hit != default(RaycastHit2D)
            ? hit.transform.GetComponent<T>()
            : null;
    }
    
    public static Transform GetTransformUnderCoursor2D(this Camera inputCamera)
    {
        var hit = Physics2D.Raycast(inputCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return hit != default(RaycastHit2D)
            ? hit.transform
            : null;
    }
}