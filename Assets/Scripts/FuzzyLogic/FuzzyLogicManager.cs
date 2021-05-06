using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicPCL;
using FuzzyLogicPCL.FuzzySets;
using UnityEngine.UI;
using TMPro;

public class FuzzyLogicManager : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public Gradient damageGradient;

    [Header("Linguistic Value Sliders")]
    public Slider distanceSlider;
    public Slider velocitySlider;
    public Slider weightSlider;



    private FuzzySystem system;
    private LinguisticVariable distancia;
    private LinguisticVariable velocidad;
    private LinguisticVariable peso;
    private LinguisticVariable damage;

    private bool slidersConfigured = false;

    private void Start()
    {
        SetSliderValues();
    }

    private void CreateSystem()
    {
        system = new FuzzySystem("Enemy Damage");
        SetLinguisticValues();
        SetRules();
    }

    private void SetLinguisticValues()
    {
        SetInputValues();
        SetOutputValues();
    }

    private void SetSliderValues()
    {
        slidersConfigured = false;
        float margin = 0.01f;

        velocitySlider.maxValue = 300 - margin;
        velocitySlider.minValue = 0 + margin;
        velocitySlider.value = 0 + margin;

        distanceSlider.maxValue = 100 - margin;
        distanceSlider.minValue = 0 + margin;
        distanceSlider.value = 0 + margin;

        weightSlider.maxValue = 50 - margin;
        weightSlider.minValue = 0 + margin;
        weightSlider.value = 0 + margin;
        slidersConfigured = true;
    }

    private void SetInputValues()
    {
        //Distancia enemigo(m)
        distancia = new LinguisticVariable("Distancia", 0, 100);
        distancia.AddValue(new LinguisticValue("Poca", new LeftFuzzySet(0, 100, 5, 15)));
        distancia.AddValue(new LinguisticValue("Media", new TrapezoidalFuzzySet(0, 100, 5, 15, 60, 70)));
        distancia.AddValue(new LinguisticValue("Mucha", new RightFuzzySet(0, 100, 60, 70)));
        system.addInputVariable(distancia);

        //Velocidad proyectil(m/s)
        velocidad = new LinguisticVariable("Velocidad", 0, 300);
        velocidad.AddValue(new LinguisticValue("Poca", new LeftFuzzySet(0, 300, 30, 50)));
        velocidad.AddValue(new LinguisticValue("Media", new TrapezoidalFuzzySet(0, 300, 40, 50, 100, 150)));
        velocidad.AddValue(new LinguisticValue("Mucha", new TrapezoidalFuzzySet(0, 300, 100, 150, 200, 240)));
        velocidad.AddValue(new LinguisticValue("Muchisima", new RightFuzzySet(0, 300, 240, 270)));
        system.addInputVariable(velocidad);

        //Peso proyectil (Kg)
        peso = new LinguisticVariable("Peso", 0, 50);
        peso.AddValue(new LinguisticValue("Poco", new LeftFuzzySet(0, 50, 0, 5)));
        peso.AddValue(new LinguisticValue("Medio", new TrapezoidalFuzzySet(0, 50, 0, 5, 20, 30)));
        peso.AddValue(new LinguisticValue("Mucho", new RightFuzzySet(0, 50, 30, 40)));
        system.addInputVariable(peso);
    }

    private void SetOutputValues()
    {
        damage = new LinguisticVariable("Damage", 0, 100);
        damage.AddValue(new LinguisticValue("Poco", new LeftFuzzySet(0, 100, 5, 20)));
        damage.AddValue(new LinguisticValue("Normal", new TrapezoidalFuzzySet(0, 100, 5, 20, 50, 70)));
        damage.AddValue(new LinguisticValue("Mucho", new RightFuzzySet(0, 100, 50, 70)));
        system.addOutputVariable(damage);
    }

    public void SetValues()
    {
        if (!slidersConfigured) return;
        CreateSystem();


        if (velocidad == null || peso == null || distancia == null) return;

        system.SetInputVariable(velocidad, (double)velocitySlider.value);
        system.SetInputVariable(peso, (double)weightSlider.value);
        system.SetInputVariable(distancia, (double)distanceSlider.value);
        
        double outDouble = system.Solve();

        int output = Mathf.RoundToInt((float)outDouble);

        float output01 = Mathf.Clamp01((float)output / 100f);
        Color textColor = damageGradient.Evaluate(output01);

        outputText.text = output.ToString();
        outputText.color = textColor;
    }

    private void SetRules()
    {
        //Lo siento mucho, pero son muchas reglas con 3 valores lingüisticos
        system.addFuzzyRule("IF Velocidad IS Muchisima THEN Damage IS Mucho");
        system.addFuzzyRule("IF Velocidad IS Mucha THEN Damage IS Mucho");
        system.addFuzzyRule("IF Velocidad IS Poca THEN Damage IS Poco");

        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Poca AND Peso IS Poco THEN Damage IS Poco");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Poca AND Peso IS Medio THEN Damage IS Normal");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Poca AND Peso IS Mucho THEN Damage IS Mucho");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Media AND Peso IS Poco THEN Damage IS Poco");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Media AND Peso IS Medio THEN Damage IS Poco");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Media AND Peso IS Mucho THEN Damage IS Normal");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Mucha AND Peso IS Poco THEN Damage IS Poco");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Mucha AND Peso IS Medio THEN Damage IS Poco");
        system.addFuzzyRule("IF Velocidad IS Media AND Distancia IS Mucha AND Peso IS Mucho THEN Damage IS Poco");
        
    }
    
}
