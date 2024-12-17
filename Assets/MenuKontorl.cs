using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.Security.Cryptography;   

public class MenuKontorl : MonoBehaviour
{

//key
private string key1 = "e940640596b8550ed86bc5c69d2a2bd4"; //set any string of 32 chars
private string iv1 = "0c7a65924e0ece49"; //set any string of 16 chars

    public InputField girissifre;
    string randomString;
    public Text verilensifre;

    void Start(){
        
    randomString = GenerateRandomString(8);
    //girissifre.contentType = InputField.ContentType.Password;
    Debug.Log("Rastgele String: " + randomString);

    string sifrelenmisyazi = AESEncryption(randomString);
    Debug.Log("Sifrelenmisyazi: " + sifrelenmisyazi);

    //string pssword = AESDecryption(sifrelenmisyazi);
   // Debug.Log("cozum: " + pssword);
   verilensifre.text = sifrelenmisyazi;
    }

public void koypala(){
       GUIUtility.systemCopyBuffer =  verilensifre.text;
}

    void Update()
    {
        
    }

    string GenerateRandomString(int length)
    {
        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;:',.<>?";

        string randomString = "";
        for (int i = 0; i < length; i++)
        {
            randomString += characters[Random.Range(0, characters.Length)];
        }

        return randomString;
    }

  public string AESEncryption(string inputData)
    {
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key1);
        AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv1);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;
 
        byte[] txtByteData = ASCIIEncoding.ASCII.GetBytes(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateEncryptor(AEScryptoProvider.Key, AEScryptoProvider.IV);
 
        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return System.Convert.ToBase64String(result);
    }
/*
public string AESDecryption(string inputData)
    {
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key1);
        AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv1);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;
 
        byte[] txtByteData = System.Convert.FromBase64String(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateDecryptor();
 
        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return ASCIIEncoding.ASCII.GetString(result);
    }*/

public void Girisbutton()
{
if(girissifre.text == randomString){
 SceneManager.LoadScene(1); 
    }else{ Debug.Log("sıfre yanlıs");}
}

}
