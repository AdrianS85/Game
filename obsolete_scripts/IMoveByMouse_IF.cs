using UnityEngine;

public interface IMoveByMouse_IF
{
    void Move(bool IsClicked_, float MovementSpeed_, Camera ReferenceCamera_, bool isTargetReached_ = true);
    //void Pickup();
    //void Attack();
}
