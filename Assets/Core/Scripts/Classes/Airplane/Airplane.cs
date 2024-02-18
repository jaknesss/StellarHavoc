using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] public Gun[] guns;
    [SerializeField] public float maxThrust;
    public Gun[] getGuns() {  return guns; }
    public float getMaxThrust() {  return maxThrust; }    

}
