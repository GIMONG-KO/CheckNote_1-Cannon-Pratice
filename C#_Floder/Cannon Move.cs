using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : MonoBehaviour
{
    public float rotationSpeed = 100f; // 회전 속도

    private void Update()
    {
        float rotationX = 0f;
        float rotationY = 0f;

        if (Input.GetKey(KeyCode.W)) // 위로 (X축 증가)
        {
            rotationX = rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) // 아래로 (X축 감소)
        {
            rotationX = -rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) // 왼쪽으로 (Y축 감소)
        {
            rotationY = -rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) // 오른쪽으로 (Y축 증가)
        {
            rotationY = rotationSpeed * Time.deltaTime;
        }

        // 기존 회전 값 가져오기
        // eulerAngles = 오일러 각도 / 물체의 회전량 = 회전 후 물체의 좌표계 – 회전하기 전 물체의 좌표계
        // N차원 공간의 회전이 N번에 나누어 걸쳐 이루어짐
        // 짐벌락 = 회전시 2개의 축이 일치할때, 회전이 버벅거리는 현상

        // 유니티에서는 쿼터니언을 자주 사용
        // Quaternion = 4개의 원소를 통해 회전을 표현하는 방법
        // Q = (W, a, B, Y) 4개의 축으로 구성
        // 쿼터니언을 이용한 회전은 N차원 공간상에서 한번에 회전(짐벌락 현상 해결 및 계산량 감소)
        // 하지만 계산이 매우 복잡하고, 유니티에서 개발자에게 제어를 허용하지 않음
        // 유니티는 오일러각 <-> 쿼터니안 각도 제어 메소드를 제공
        //  Q = (W, a, B, Y) 에서, a, B, Y 가 3차원 백터
        // 개발자는 백터의 형태로 회전을 다룰 필요가 있을 때에만, 쿼터니안으로 변환해서 사용

        // 새로운 쿼티니언 필드 생성 메서드

        //  Quaternion.Euler(Vector3); 오일러 각도를 쿼터니언 각도로 변환
        //  Quaternion.eulerAngles; 쿼터니언 각도를 오일러 각도로 변환
        //  Quaternion.Rotation = Quaternion.Euler(nwe Vector3(0, 0, 0));
        //  쿼터니언 각도를 사용한 상태에서, 현재 회전에서 추가로 더 회전하려면
        //  현재회전 * 추가로 더 회전(곱셈값으로 계산)
        
        // 0_오브젝트의 월드 공간에서의 현재 회전을 오일러 각도로 변환
        Vector3 currentRotation = transform.eulerAngles;
        
        // 1_Y축 회전값 계산
        currentRotation.y += rotationY;

        // 2_X축 회전값 계산
        // Euler 각도를 -180 ~ 180으로 변환(오일러 각도는 기본적으로 0 ~ 360도로 표현됨)
        currentRotation.x = (currentRotation.x > 180) ? currentRotation.x - 360 : currentRotation.x;
        // X축 회전값을 -30 ~ 30으로 제한
        currentRotation.x = Mathf.Clamp(currentRotation.x + rotationX, -30, 30);
        // 다시 0 ~ 360도로 변환
        currentRotation.x = (currentRotation.x < 0) ? currentRotation.x + 360 : currentRotation.x;

        // 3_X,Y 축의 회전값 적용
        transform.eulerAngles = currentRotation;
    }

}
