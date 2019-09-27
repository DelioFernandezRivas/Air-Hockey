using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia : MonoBehaviour
{
    public float posicioniax;
    public float posicioniay;
    public Rigidbody disco;
    public Discosalejugador discoctrl;
    public Vector3 vectorpelota;
    public Vector3 posicion;
    public Vector3 posicioninicial;
    public Quaternion posicioninicialrotation;
    public GameObject discogameobject;
    public Vector3 vectordiscosale;
    [Range(0, 1)]
    public float habilidad;
    void Start()
    {
        posicioninicial = transform.position;
        posicioninicialrotation = transform.rotation;
        vectorpelota = new Vector3(Random.Range(2f, 3f), 0f, Random.Range(2f, 3f));
    }

    void FixedUpdate()
    {
        ia();
    }


    public void ia()
    {

        if (discoctrl.transform.position.x < 0 && (discoctrl.transform.position.y > 1.5f || discoctrl.transform.position.y < 1.6f) && (discoctrl.transform.position.z < 0.8f || discoctrl.transform.position.z > -0.8f))
        {
            Vector3 nuevaposicion = transform.position;
        nuevaposicion.z = Mathf.Lerp(transform.position.z, disco.transform.position.z, habilidad);
        transform.position = nuevaposicion;

        if (disco.transform.IsChildOf(gameObject.transform))
        {
            discoctrl.gameObject.GetComponent<Rigidbody>().velocity = vectorpelota;
            discoctrl.gameObject.transform.SetParent(null);
            discoctrl.sacarjugador2 = false;

        }

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mesa")
        {
            posicionreferenciaia();

        }
    }
    IEnumerator sacar() {

        yield return new WaitForSeconds(3f);
    }
    public void posicionreferenciaia()
    {
        transform.position = posicioninicial;
        transform.rotation = posicioninicialrotation;
    }
}
