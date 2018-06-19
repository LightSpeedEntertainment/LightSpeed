using UnityEngine;
using System.Collections.Generic;

public class Telekinesis : MonoBehaviour {
	
	public Rigidbody[] m_Rigidbodies;

	public Transform m_lookDirection;

	public Material _Near;
	public Material _Far;
	public Material _Grabbed;
	public Material _Pushed;

	public float _closestDistance = 2f;
	public float _range = 5f;
	public float _pullForce = 10f;
	public float _pushForce = 25f;
	public float _crushForce = 5f;
	public float _minSize;
	public float _maxSize;

	private float _size;

	private float _distance;

	private void FixedUpdate()
	{
		m_Rigidbodies = GameObject.FindObjectsOfType<Rigidbody>();

		for (int i = 0; i < m_Rigidbodies.Length; i++)
		{
			if (m_Rigidbodies[i].tag != "Player")
			{
				_distance = Vector3.Distance(m_Rigidbodies[i].position, transform.position);

				if (_distance <= _range)
				{
					m_Rigidbodies[i].GetComponent<MeshRenderer>().material = _Near;

					if (Input.GetKey(KeyCode.Space))
					{
						Vector3 direction = (transform.position -
							m_Rigidbodies[i].position) -
							m_Rigidbodies[i].transform.forward *
							_closestDistance;

						Pull(m_Rigidbodies[i], direction, false);
					}
					else
						m_Rigidbodies[i].useGravity = true;

					if (Input.GetKey(KeyCode.LeftShift))
					{
						Vector3 direction = m_lookDirection.transform.forward;

						Push(m_Rigidbodies[i], direction, true);
					}

					if (Input.GetKey(KeyCode.E))
					{
						_size += 1f * _crushForce;
						_size = Mathf.Clamp(_size, _minSize, _maxSize);
						m_Rigidbodies[i].transform.localScale = Vector3.one * _size;
						m_Rigidbodies[i].mass = _size;
					}

					if (Input.GetKey(KeyCode.R))
					{
						_size -= 1f * _crushForce;
						_size = Mathf.Clamp(_size, _minSize, _maxSize);
						m_Rigidbodies[i].transform.localScale = Vector3.one * _size;
						m_Rigidbodies[i].mass = _size;
					}
				}
				else
					m_Rigidbodies[i].GetComponent<MeshRenderer>().material = _Far;
			}
		}
	}

	private void Pull(Rigidbody _actor, Vector3 _direction, bool _useGravity)
	{
		_actor.GetComponent<MeshRenderer>().material = _Grabbed;
		_actor.useGravity = _useGravity;

		_actor.transform.LookAt(transform.position);

		_actor.AddForce(_direction * _pullForce, ForceMode.Force);
	}

	private void Push(Rigidbody _actor, Vector3 _direction, bool _useGravity)
	{
		_actor.GetComponent<MeshRenderer>().material = _Pushed;
		_actor.useGravity = _useGravity;

		_actor.AddForce(_direction * _pushForce, ForceMode.Force);
	}
}