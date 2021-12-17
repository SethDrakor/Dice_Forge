using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider gloireSlider;
    public Slider orSlider;
    public Slider eclatSolaireSlider;
    public Slider eclatLunaireSlider;

    public void SetHUD(Unit unit)
    {
    
        gloireSlider.maxValue = unit.ptGloire;
        gloireSlider.value = 100;
        orSlider.maxValue = unit.or;
        orSlider.value = unit.currentOr;
        eclatSolaireSlider.maxValue = unit.eclatSolaire;
        eclatSolaireSlider.value = unit.currentEclatSolaire;
        eclatLunaireSlider.maxValue = unit.eclatLunaire;
        eclatLunaireSlider.value = unit.currentEclatLunaire;
    }

    public void SetGLOIRE(int gloire)
    {
        gloireSlider.value = gloire;
    }

    public void SetOR(int or)
    {
        orSlider.value = or;
    }

    public void SetECLATSOLAIRE(int eclatSolaire)
    {
        eclatSolaireSlider.value = eclatSolaire;
    }

    public void SetECLATLUNAIRE(int eclatLunaire)
    {
        eclatLunaireSlider.value = eclatLunaire;
    }
}
