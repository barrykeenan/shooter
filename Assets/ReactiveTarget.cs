using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        // destroy object this script is attached to
        Destroy(this.gameObject);
    }
}
