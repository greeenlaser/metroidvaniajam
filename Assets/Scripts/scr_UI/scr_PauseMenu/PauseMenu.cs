using System.Collections;
using System.Collections.Generic;
using scr_UI.scr_Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace scr_UI.scr_PauseMenu
{
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
    public class PauseMenu : MonoBehaviour
========
    public class MainMenuButtons : MonoBehaviour
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
========
    public class MainMenuButtons : MonoBehaviour
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
    {
        public List<Button> buttons = new List<Button>();
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
        public List<Canvas> canvases = new List<Canvas>();
        private readonly List<Vector2> _buttonStartingPositions = new List<Vector2>();
========
        private List<Vector2> _buttonStartingPositions = new List<Vector2>();
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
========
        private List<Vector2> _buttonStartingPositions = new List<Vector2>();
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
        private Button _selectedButton;

        private readonly Vector2 _openMenuPos = new Vector2(394, 350);
        private Vector2 _hiddenPos;

<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
        [SerializeField] private Canvas statsCanvas;

        [SerializeField] private float buttonMoveTime;
========
        protected readonly Color32 DefaultColor = new Color32(159, 159, 159, 255);
        protected readonly Color32 SelectedColor = new Color32(255, 255, 255, 255);
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
========
        protected readonly Color32 DefaultColor = new Color32(159, 159, 159, 255);
        protected readonly Color32 SelectedColor = new Color32(255, 255, 255, 255);
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs

        public void Start()
        {
            foreach (var button in buttons)
            {
                _buttonStartingPositions.Add(button.GetComponent<RectTransform>().anchoredPosition);
                button.image.color = Colors.DefaultMenuButtonColor;
            }
        }

        public void Update()
        {
            foreach (var button in buttons)
            {
                button.onClick.AddListener
                (() =>
                    {
                        _selectedButton = button;
                        if (_selectedButton.name.Equals("ExitButton"))
                        {
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
                            CloseMenu();
========
                            Application.Quit();
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
========
                            Application.Quit();
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
                        }
                        else if (_selectedButton != null)
                        {
                            StopAllCoroutines();
                            CanvasController.HideCanvas(statsCanvas);
                            ActivateSelectedMenu(_selectedButton);
                            HideButtons();
                        }
                    }
                );
            }

            if (Input.GetKeyDown(KeyCode.Escape) && _selectedButton != null)
            {
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
                ResetButtonPositions();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _selectedButton == null)
            {
                CloseMenu();
            }
========
                _selectedButton.GetComponent<MainMenuButtons>().enabled = true;
                _selectedButton = null;
                ResetButtonPositions();
            }
            
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
========
                _selectedButton.GetComponent<MainMenuButtons>().enabled = true;
                _selectedButton = null;
                ResetButtonPositions();
            }
            
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
        }

        private void CloseMenu()
        {
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
<<<<<<<< HEAD:Assets/Scripts/scr_UI/scr_PauseMenu/PauseMenu.cs
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        private void ActivateSelectedMenu(Button btn)
        {
            btn.image.color = Colors.HighlightedMenuButtonColor;
            _selectedButton.GetComponent<MenuButtonHover>().enabled = false;
            CanvasController.ShowCanvas(canvases[buttons.IndexOf(btn)]);
========
            btn.image.color = SelectedColor;
            _selectedButton.GetComponent<MainMenuButtons>().enabled = false;
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
========
            btn.image.color = SelectedColor;
            _selectedButton.GetComponent<MainMenuButtons>().enabled = false;
>>>>>>>> dev:Assets/Scripts/scr_UI/MainMenuButtons.cs
            StartCoroutine(MoveButtons(btn, _openMenuPos));
        }

        private void HideButtons()
        {
            foreach (var button in buttons)
            {
                if (button != _selectedButton)
                {
                    _hiddenPos = new Vector2(-248, button.GetComponent<RectTransform>().anchoredPosition.y);
                    StartCoroutine(MoveButtons(button, _hiddenPos));
                }
            }
        }

        private void ResetButtonPositions()
        {
            StopAllCoroutines();
            CanvasController.ShowCanvas(statsCanvas);
            CanvasController.HideCanvas(canvases[buttons.IndexOf(_selectedButton)]);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].image.color = Colors.DefaultMenuButtonColor;
                StartCoroutine(MoveButtons(buttons[i], _buttonStartingPositions[i]));
            }
            _selectedButton.GetComponent<MenuButtonHover>().enabled = true;
            _selectedButton = null;
        }

        private IEnumerator MoveButtons(Button btn, Vector2 endPos)
        {
            var currentPos = btn.GetComponent<RectTransform>().anchoredPosition;
            var startPos = currentPos;
            var transitionTime = 0f;

            while (Vector2.Distance(startPos, endPos) > 0.1f)
            {
                currentPos = Vector2.Lerp(startPos, endPos, transitionTime);

                transitionTime += buttonMoveTime;

                btn.GetComponent<RectTransform>().anchoredPosition = currentPos;

                yield return null;
            }
        }
    }
}
