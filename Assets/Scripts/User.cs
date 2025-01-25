using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] public int _lifes = 3;
    [SerializeField] public float _money = 100;
    [SerializeField] private float _moneyCoef = 1.1f;

    public void decreaseLife(){
        this._lifes -= 1;
        if(this._lifes == 0) 
            Debug.Log("Game Over");
    }
    public void increaseMoney(float bubbleSize){
        this._money *= _moneyCoef;
        Debug.Log("User Money: " + this._money + "$");
    }
}
