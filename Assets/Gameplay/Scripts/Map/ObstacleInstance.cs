using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstance : MonoBehaviour
{
    public TypeObstacles typeObstacles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ConstantManager.BALL))
        {
            switch (typeObstacles)
            {
                case TypeObstacles.pumper:
                    PlayerManager.Instance.ChangeState(StateSizeBall.big);
                    break;
                case TypeObstacles.deflater:
                    PlayerManager.Instance.ChangeState(StateSizeBall.small);
                    break;
                case TypeObstacles.power_gravity:
                    PlayerManager.Instance.SetGravityBall(-1);
                    break;
                case TypeObstacles.power_speed:
                    PlayerManager.Instance.SetSpeedBall(-1);
                    break;
                case TypeObstacles.power_jump:
                    PlayerManager.Instance.SetJumpBall(800);
                    break;
                case TypeObstacles.dyn_thorn:
                    PlayerManager.Instance.ChangeState(StateSizeBall.pop);
                    GameManager.Instance.ChangeState(GameState.EndGame);
                    break;
                case TypeObstacles.thorn:
                    PlayerManager.Instance.ChangeState(StateSizeBall.pop);
                    GameManager.Instance.ChangeState(GameState.EndGame);
                    break;
            }
        }
    }
}
