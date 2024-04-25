using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MisTests {
    // Referencia al objeto cubo
    public GameObject cubeObject;

    // ORDER, se ejecutan en orden alfab�tico a no ser que indiques el orden en Order

    // Pruebas de integraci�n (con el Play)
    // Si no se especifica el orden, los tests se ejecutan
    // por orden alfab�tico y eso podr�a no funcionar
    [UnityTest, Order(1)]
    public IEnumerator Inicio() {
        SceneManager.LoadScene("SimpleTests"); // Cargamos la escena
        yield return null; // Esperamos a que se dibuje el primer frame
        cubeObject = GameObject.Find("Cube"); // Localizamos el cubo
    }

    // Pruebas unitarias (sin el Play)
    // Se debe ejecutar despu�s del anterior test porque
    // hay que garantizar que se ha dibujado el primer frame
    // para despu�s buscar el cubo en la escena
    [Test, Order(2)]
    public void ExisteObjetoCuboEnLaEscena() {
        Assert.IsNotNull(cubeObject); // Comprobamos que exista
    }

    // Verifica si el cubo est� e la posici�n que deber�a estar
    // Se debe ejecutar despu�s de que se haya dibujado el primer
    // frame del juego para garantizar que el objeto exista
    [Test, Order(3)]
    public void EstaCuboEnLasCoordenadasCero() {
        Assert.AreEqual(Vector3.zero, cubeObject.transform.position);
    }
}
