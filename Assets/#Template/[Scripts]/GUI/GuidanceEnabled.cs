using UnityEngine;
using UnityEngine.UI;

namespace DancingLineFanmade.Guideline
{
    [DisallowMultipleComponent]
    public class GuidanceEnabled : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Image background;
        [SerializeField] private Sprite on;
        [SerializeField] private Sprite off;

        private GuidelineManager controller;

        private void Start()
        {
            controller = FindFirstObjectByType<GuidelineManager>();
            int guidanceEnabled = PlayerPrefs.GetInt("GuidanceEnabled", 1);
            if (!controller)
            {
                gameObject.SetActive(false);
                return;
            }


            SetGuidance(guidanceEnabled == 1);

            if (!controller.guidelineTapHolder)
            {
                GetComponent<Button>().interactable = false;
                foreach (Image i in GetComponentsInChildren<Image>())
                {
                    i.enabled = false;
                    i.raycastTarget = false;
                }
                background.enabled = false;
                background.raycastTarget = false;
            }
        }

        public void OnClick()
        {
            SetGuidance(PlayerPrefs.GetInt("GuidanceEnabled", 1) == 0);
        }

        private void SetGuidance(bool enabled)
        {
            if (enabled)
            {
                image.sprite = on;
                if (controller.guidelineTapHolder) controller.guidelineTapHolder.gameObject.SetActive(true);
            }
            else
            {
                image.sprite = off;
                if (controller.guidelineTapHolder) controller.guidelineTapHolder.gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt("GuidanceEnabled", enabled ? 1 : 0);
        }
    }
}