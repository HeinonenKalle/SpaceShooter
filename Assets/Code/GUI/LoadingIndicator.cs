﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Systems;
using System;
using DG.Tweening;

namespace SpaceShooter.GUI
{
    public class LoadingIndicator : MonoBehaviour
    {
        [SerializeField]
        private Image _indicatorImage;

        [SerializeField]
        private Image _backgroundImage;

        private Coroutine _rotateCoroutine;
        
        void Awake()
        {
            gameObject.SetActive(false);
            Global.Instance.GameManager.GameStateChanging += HandleGameStateChanging;
            Global.Instance.GameManager.GameStateChanged += HandleGameStateChanged;
        }
        
        protected void OnDestroy()
        {
            Global.Instance.GameManager.GameStateChanging -= HandleGameStateChanging;
            Global.Instance.GameManager.GameStateChanged -= HandleGameStateChanged;
        }

        private void HandleGameStateChanged(GameStateType obj)
        {
            StopCoroutine(_rotateCoroutine);
            _rotateCoroutine = null;

            var tweener = DOTween.To(() => _backgroundImage.color, (value) => _backgroundImage.color = value, new Color(0, 0, 0, 0), 0.5f);
            tweener.OnComplete(TweenCompleted);
        }

        private void TweenCompleted()
        {
            gameObject.SetActive(false);
        }

        private void HandleGameStateChanging(GameStateType obj)
        {
            gameObject.SetActive(true);
            _rotateCoroutine = StartCoroutine(Rotate());

            _backgroundImage.color = new Color(0, 0, 0, 0);
            DOTween.To( () => _backgroundImage.color, (value) => _backgroundImage.color = value, Color.black, 0.5f);
        }

        private IEnumerator Rotate()
        {
            while (true)
            {
                _indicatorImage.transform.Rotate(Vector3.forward, -180 * Time.deltaTime, Space.Self);
                yield return null;
            }
        }
    }
}
