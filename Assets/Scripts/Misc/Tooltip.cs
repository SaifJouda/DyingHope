using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Tooltip : MonoBehaviour {
	private SpriteRenderer sr;
	public float waitTime = 0f;
	public float showTime = 7f;

	private void Start() {
		sr = GetComponent<SpriteRenderer>();
		sr.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		StartCoroutine(Show());
	}

	private IEnumerator Show() {
		yield return new WaitForSecondsRealtime(waitTime);

		sr.enabled = true;

		yield return new WaitForSecondsRealtime(showTime);

		Destroy(gameObject);
	}
}
