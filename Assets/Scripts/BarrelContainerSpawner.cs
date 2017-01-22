using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelContainerSpawner : MonoBehaviour {

  public HingeJoint m_LeftDoorJoint;
  public HingeJoint m_RightDoorJoint;

  public float m_BarrelDelay = 1;

  private ElementSpawner m_ElementSpawner;


  void Start() {
    m_ElementSpawner = GetComponent<ElementSpawner> ();
  }

  public void Release () {
    ApplySprings ();

    // wait 1sec

    StartCoroutine (ReleaseBarrelsInSeconds (m_BarrelDelay));
  } 


  IEnumerator ReleaseBarrelsInSeconds(float seconds) {
    yield return new WaitForSeconds(seconds);
    ReleaseBarrels ();
  }

  void ApplySprings() {
    JointSpring leftSpring = new JointSpring ();
    leftSpring.spring = 2000;
    leftSpring.targetPosition = m_LeftDoorJoint.limits.max;;
    m_LeftDoorJoint.spring = leftSpring;

    JointSpring rightSpring = new JointSpring ();
    rightSpring.spring = 2000;
    rightSpring.targetPosition = m_RightDoorJoint.limits.min;
    m_RightDoorJoint.spring = rightSpring;
  }

  void ReleaseBarrels() {
		StartCoroutine(m_ElementSpawner.Release ());
  }
}
