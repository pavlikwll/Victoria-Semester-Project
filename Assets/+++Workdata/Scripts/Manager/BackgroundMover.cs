using System;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
        public Animator _backgroundAnimator;
        public Animator _titleAnimator;


    /*
     public RectTransform backgroundContainer; //der Container, der die Position verändern soll (BackgroundContainer)
public float screenHeight = 2160f; //die Anzahl der Pixel um die wir auf y verschieben pro Bildabschnitt
*/

    void Start()
        {
           //backgroundContainer.anchoredPosition = new Vector2(0, -screenHeight * 1);
           
           _backgroundAnimator.Play("MainMenuBackground"); //damit der hintergund an der mainmenu position startet
           //_titleAnimator.Play("default"); //damit der Game Title noch nicht mit der Bewegung beginnt
          
        }

      /*  #region Positions //hat nach canvas rescaling nicht mehr funktioniert

        public void ShowOptions() // (auf y-Achse)
        {
            ScrollTo(0); //Scrollt den Hintergrund an eine bestimmte Stelle
        }
    
        
        public void ShowMainMenu() // 
        {
            ScrollTo(1);
        }
    
        
        public void ShowPreGame() // 
        {
            ScrollTo(2);
        }
    
       
        public void ShowStartGame() // 
        {
            ScrollTo(3);
        }
    
        
    
        private void ScrollTo(int screenIndex) //Logik
        {
            float targetY = -screenHeight * screenIndex;
            backgroundContainer.anchoredPosition = new Vector2(0, targetY); //"bewege Anchorposition dorthin"
        }
        
        #endregion
        */
        
        #region Animation

        public void BeginningAnim()
        {
            _backgroundAnimator.SetTrigger("MainMenu");
           // _titleAnimator.Play("MainMenuTitleMove");
            _titleAnimator.SetTrigger("Beginning");
        }

        public void AnimMainMenu()
        {
            _backgroundAnimator.SetTrigger("MainMenu");
        }

        public void AnimLoadGame()
        {
            _backgroundAnimator.SetTrigger("LoadGame");
        }

        public void AnimLevelSelect()
        {
            _backgroundAnimator.SetTrigger("StartGame");
        }
         public void AnimOptions()
         {
             _backgroundAnimator.SetTrigger("Options");
         }
        #endregion
    
}