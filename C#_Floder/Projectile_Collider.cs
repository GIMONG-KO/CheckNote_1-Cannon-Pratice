using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Collider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 충돌이 발생했음을 로그로 출력
        Debug.Log($"충돌 발생! 충돌한 오브젝트 이름: {other.gameObject.name}");
        
        
        // 충돌한 다른 오브젝트가 "Monster" 태그를 가지고 있는지 확인
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Debug.Log($"충돌한 오브젝트는 Monster입니다. 오브젝트를 파괴합니다: {other.gameObject.name}");
            
            // 충돌한 다른 오브젝트 파괴
            Destroy(other.gameObject);
        }
        // 현재 오브젝트 파괴
        Debug.Log($"현재 오브젝트 {gameObject.name}를 파괴합니다.");
        
        
        // 현재 오브젝트 파괴
        Destroy(gameObject);
    }
  
}

