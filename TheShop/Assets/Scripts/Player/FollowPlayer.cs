using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.Player
{
    public class FollowPlayer : MonoBehaviour
    {
        private Transform _transform;
        private Transform playerTransform;

        public float baseSpeed = 5;

        // Start is called before the first frame update
        private void Start()
        {
            _transform = transform;
        }

        // Update is called once per frame
        private void Update()
        {
            if (playerTransform == null)
            {
                TryFindPlayer();

                return;
            }

            float dist = Vector3.Distance(_transform.position, playerTransform.position);

            _transform.position = Vector3.Lerp(_transform.position, playerTransform.position, (baseSpeed + dist) * Time.deltaTime);
        }

        private void TryFindPlayer()
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            if (go != null)
            {
                playerTransform = go.transform;
            }
        }
    }
}