using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

    public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
    {
        [Header("Slider setup")]
        [SerializeField, Range(0, 1f)]
        protected float sliderValue;
        public bool CurrentValue { get; private set; }

        private bool previousValue;
        private Slider slider;

        [Header("Animation")]
        [SerializeField, Range(0, 1f)] private float animationDuration = 0.5f;
        [SerializeField]
        private AnimationCurve slideEase =
            AnimationCurve.EaseInOut(0, 0, 1, 1);

        private Coroutine _animateSliderCoroutine;

        [Header("Events")]
        [SerializeField] private UnityEvent onToggleOn;
        [SerializeField] private UnityEvent onToggleOff;

        protected Action transitionEffect;

        protected virtual void OnValidate()
        {
            SetupToggleComponents();

            slider.value = sliderValue;
        }

        private void SetupToggleComponents()
        {
            if (slider != null)
                return;

            SetupSliderComponent();
        }

        private void SetupSliderComponent()
        {
            slider = GetComponent<Slider>();

            if (slider == null)
            {
                Debug.Log("No slider found!", this);
                return;
            }

            slider.interactable = false;
            var sliderColors = slider.colors;
            sliderColors.disabledColor = Color.white;
            slider.colors = sliderColors;
            slider.transition = Selectable.Transition.None;
        }



        protected virtual void Awake()
        {
            SetupSliderComponent();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Toggle();
        }


        private void Toggle()
        {
            
                SetStateAndStartAnimation(!CurrentValue);
        }

        public void ToggleByGroupManager(bool valueToSetTo)
        {
            SetStateAndStartAnimation(valueToSetTo);
        }


        private void SetStateAndStartAnimation(bool state)
        {
            previousValue = CurrentValue;
            CurrentValue = state;

            if (previousValue != CurrentValue)
            {
                if (CurrentValue)
                    onToggleOn?.Invoke();
                else
                    onToggleOff?.Invoke();
            }

            if (_animateSliderCoroutine != null)
                StopCoroutine(_animateSliderCoroutine);

            _animateSliderCoroutine = StartCoroutine(AnimateSlider());
        }


        private IEnumerator AnimateSlider()
        {
            float startValue = slider.value;
            float endValue = CurrentValue ? 1 : 0;

            float time = 0;
            if (animationDuration > 0)
            {
                while (time < animationDuration)
                {
                    time += Time.deltaTime;

                    float lerpFactor = slideEase.Evaluate(time / animationDuration);
                    slider.value = sliderValue = Mathf.Lerp(startValue, endValue, lerpFactor);

                    transitionEffect?.Invoke();

                    yield return null;
                }
            }

            slider.value = endValue;
        }
    }

