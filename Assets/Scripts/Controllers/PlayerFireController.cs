using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PlayerFireController : MonoBehaviour
    {
        [SerializeField] GameObject shot;
        [SerializeField] GameObject shotSpawn;
        [SerializeField] float nextFire;
        [SerializeField] float fireRate;
        [SerializeField] float tripleBulletAngel;

        float fireRateBackUp;
        Vector3 firePosition;
        Vector3 fireRotation;
        AudioSource audioPlayer;
        int _powerUpLevel = 1;

        void Awake()
        {
            audioPlayer = GetComponent<AudioSource>();
            fireRateBackUp = fireRate;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                FireBullet();
                audioPlayer.Play();
            }
        }

        private void FireBullet()
        {
            firePosition = shotSpawn.transform.position;
            fireRotation = shotSpawn.transform.rotation.eulerAngles;

            if (_powerUpLevel == 1)
            {
                SpawnNewBolt(firePosition, Quaternion.Euler(fireRotation));
            }
            else if (_powerUpLevel == 2)
            {
                SpawnNewBolt(new Vector3(firePosition.x + .1f, firePosition.y, firePosition.z), Quaternion.Euler(fireRotation));
                SpawnNewBolt(new Vector3(firePosition.x - .1f, firePosition.y, firePosition.z), Quaternion.Euler(fireRotation));
            }
            else if (_powerUpLevel == 3)
            {
                SpawnNewBolt(new Vector3(firePosition.x + .1f, firePosition.y, firePosition.z), Quaternion.Euler(new Vector3(fireRotation.x, fireRotation.y + tripleBulletAngel, fireRotation.z)));
                SpawnNewBolt(new Vector3(firePosition.x, firePosition.y, firePosition.z), Quaternion.Euler(fireRotation));
                SpawnNewBolt(new Vector3(firePosition.x - .1f, firePosition.y, firePosition.z), Quaternion.Euler(new Vector3(fireRotation.x, fireRotation.y - tripleBulletAngel, fireRotation.z)));
            }
        }

        private void SpawnNewBolt(Vector3 vector,Quaternion quaternion)
        {
            GameObject newPlayerBolt = PoolSignals.Instance.onGetEntityFromPool.Invoke(EntityTypes.PlayerBolt);
            newPlayerBolt.transform.position = vector;
            newPlayerBolt.transform.rotation = quaternion;
            newPlayerBolt.SetActive(true);
        }

        public void OnIncreasePowerUpLevel()
        {
            _powerUpLevel++;
            _powerUpLevel = Mathf.Clamp(_powerUpLevel, 1, 3);
            if (_powerUpLevel == 2)
            {
                fireRate -= 0.1f; 
            }
            else
            {
                ResetFireRate();
            }
        }

        public void OnResetPowerUpLevel()
        {
            _powerUpLevel = 1;
            ResetFireRate();
        }

        public bool OnGetIsPowerUpLevelMax()
        {
            return _powerUpLevel == 3;
        }

        private void ResetFireRate()
        {
            fireRate = fireRateBackUp;
        }       
    }
}