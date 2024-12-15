using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;

    public GameObject firePoint;

    public Slider slider;
    public float maxPower;
    public float currentPower;
    public float fillSpead = 40f;
    public float downSpeed = 5f;
    
    private bool isFilling = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // 스페이스바를 누르고 있을 때
            if (Input.GetKey(KeyCode.Space))
            {
                if (isFilling) // 증가 상태
                {
                    currentPower += fillSpead * Time.deltaTime;

                    // 게이지가 최대치에 도달하면 감소 상태로 전환
                    if (currentPower >= maxPower)
                    {
                        currentPower = maxPower;
                        isFilling = false; // 감소로 전환
                    }
                }
                else // 감소 상태
                {
                    currentPower -= downSpeed * Time.deltaTime;

                    // 게이지가 최소치에 도달하면 다시 증가 상태로 전환
                    if (currentPower <= 0)
                    {
                        currentPower = 0;
                        isFilling = true; // 증가로 전환
                    }
                }

                // 슬라이더 업데이트
                slider.value = currentPower / maxPower;
            }

        }

        if (Input.GetKey(KeyCode.Space))
        {
            currentPower += fillSpead * Time.deltaTime;
            currentPower = Mathf.Clamp(currentPower, 0, maxPower);
            slider.value = currentPower / maxPower;
        }

       
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // 포탄 인스턴스를 생성
            GameObject cannonBallInstance = Instantiate(cannonBall, 
                firePoint.transform.position, 
                Quaternion.identity); // 회전값을 그대로 사용하려면 Quaternion.identity

            // firePoint의 Z축 방향을 사용하여 발사
            Vector3 launchDirection = firePoint.transform.forward;

            // 발사체에 힘을 가함
            cannonBallInstance.GetComponent<Rigidbody>().AddForce(launchDirection * currentPower, ForceMode.Impulse);

            // 발사 후 초기화
            currentPower = 0.0f;
            slider.value = 0.0f;
        }
    }
}
