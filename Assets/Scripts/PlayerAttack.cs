using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public Animator anim;

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetMouseButton(0) && !anim.GetBool("Attack"))
        {

            StartCoroutine(attack());

            foreach (GameObject item in enemies)
            {
                if (Vector3.Distance(item.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.75f)
                    item.GetComponent<Enemy>().TakeDamage(10);
            }
        }
    }

    private IEnumerator attack()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Attack", false);
    }

}
