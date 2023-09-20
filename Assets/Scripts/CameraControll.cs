
using Unity.Mathematics;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Transform player;
    public float xMax, yMax, xMin,yMin;
    private string playerTag = "Player";
    private float getX,x;
    private float getY,y;
    // Update is called once per frame
    private void Start()
    {
       
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng có tag là Player.");
        }
    }
    private void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        x = math.max(xMin, player.position.x);
        getX = math.min(xMax, x);               
/*  TH1:       Nếu player ơ vị trí nhỏ hơn -6;
        vd player.positon.x =-7 ==> X_min=-6; ==> getX = -6 

   TH2:     Nếu player ở vị trí lớn hơn 6 :
        vd player.positon.x = 7 ==> X_min= 7 ; ==> getX = 6;

Muc dich cho toa do X cua Camera  nằm trong khoảng (-6, 6)
*/
        y = math.max(yMin, player.position.y);
        getY = math.min(yMax, y);
        transform.position = new Vector3(getX,getY, transform.position.z);
    }
}
