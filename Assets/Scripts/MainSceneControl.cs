using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneControl : MonoBehaviour {

	public Transform moveTransform;
	public Camera mainCamera;
	public float moveDelta = 1f;

	// Use this for initialization
	void Start () {

	}

	#if UNITY_EDITOR || UNITY_STANDALONE
	Vector3 lastMousePosition = Vector2.zero;
	#endif

	public Vector3[] axisNormals = {
		new Vector3(1, 0, 0),
		new Vector3(0, 1, 0),
		new Vector3(0, 0, 1)
	};

	enum Axis {
		AxisX = 0,
		AxisY,
		AxisZ
	};

	Axis? selectingAxis = null;

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			lastMousePosition = Input.mousePosition;
		#elif UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE
		if (Input.touchCount > 0) {
			var touch = Input.touches[0];
			Ray ray = mainCamera.ScreenPointToRay(touch.position);
			if (touch.phase == TouchPhase.Began)
		#endif
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.CompareTag("AxisX")) {
					selectingAxis = Axis.AxisX;
					Debug.Log("Selected AxisX");
				} else if (hit.transform.CompareTag("AxisY")) {
					selectingAxis = Axis.AxisY;
					Debug.Log("Selected AxisY");
				} else if (hit.transform.CompareTag("AxisZ")) {
					selectingAxis = Axis.AxisZ;
					Debug.Log("Selected AxisZ");
				}
			}
		}
		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButton(0) && selectingAxis != null) {
			var delta = Input.mousePosition - lastMousePosition;
			lastMousePosition = Input.mousePosition;
		#elif UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE
		if (Input.touchCount > 0 && selectingAxis != null) {
			var touch = Input.touches[0];
			var deltaVec2 = touch.deltaPosition;
			var delta = new Vector3(deltaVec2.x, deltaVec2.y, 0);
		#endif
			Debug.Log(delta);
			var selectingNormal = axisNormals[(int)selectingAxis.Value];
			var viewAxis = mainCamera.WorldToViewportPoint(moveTransform.position + selectingNormal);
			var viewOri = mainCamera.WorldToViewportPoint(moveTransform.position);
			viewAxis.z = 0f;
			Debug.Log("ViewAxis: " + viewAxis);
			Debug.Log("delta: " + delta);
			var projection = Vector3.Project(delta, viewAxis - viewOri);
			int dir = 0;
			var angle = Mathf.Abs(Vector3.Angle(projection, viewAxis - viewOri));
			Debug.Log("Angle: " + angle);
			if (angle > 90f) dir = -1;
			else dir = 1;
			var finalMove = selectingNormal * Vector3.Normalize(projection).magnitude * moveDelta * dir;
			Debug.Log("Final Move: " + projection);

			var resPos = moveTransform.position;
			resPos += finalMove;
			moveTransform.position = resPos;
			// switch (selectingAxis.Value) {
			// 	case Axis.AxisX:
			// 	break;

			// 	case Axis.AxisY:
			// 	break;

			// 	case Axis.AxisZ:
			// 	break;
			// }
		}

		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButtonUp(0)) {
		#elif UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE
		if (Input.touchCount > 0) {
			var touch = Input.touches[0];
			if (touch.phase == TouchPhase.Ended)
		#endif
			selectingAxis = null;
		}
	}
}
