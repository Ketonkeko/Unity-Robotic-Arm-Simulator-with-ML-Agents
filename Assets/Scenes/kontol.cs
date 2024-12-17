/*using UnityEngine;
using UnityEngine.UI;

public class RobotControllerWithSliders : MonoBehaviour
{
    public Transform robotBase; // Robot kolun temel noktası
    public Transform arm; // Robot kolunun kendisi
    public Transform endEffector; // Robot kolunun uç kısmı

    public Slider baseSlider; // Genel dönüşü ayarlayan slider
    public Slider armSlider; // Kolun kendiyle yaptığı açıyı ayarlayan slider
    public Slider endEffectorSlider; // Kolun ucundaki tutucu kısmın açıklığını ayarlayan slider

    public float baseRotationRange = 360f; // Genel dönüş aralığı (derece cinsinden)
    public float armRotationRange = 180f; // Kolun kendiyle yaptığı açı aralığı (derece cinsinden)
    public float endEffectorRotationRange = 90f; // Uç kısmın açıklık aralığı (derece cinsinden)

    void Update()
    {
        // Genel dönüşü kontrol et
        float baseRotation = baseSlider.value / baseSlider.maxValue * baseRotationRange;
        robotBase.localRotation = Quaternion.Euler(0f, baseRotation, 0f);

        // Kolun kendiyle yaptığı açıyı kontrol et
        float armRotation = armSlider.value / armSlider.maxValue * armRotationRange;
        arm.localRotation = Quaternion.Euler(0f, 0f, armRotation);

        // Uç kısmın açıklığını kontrol et
        float endEffectorRotation = endEffectorSlider.value / endEffectorSlider.maxValue * endEffectorRotationRange;
        endEffector.localRotation = Quaternion.Euler(0f, 0f, endEffectorRotation);
    }
}
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO.Ports;
using System.Text;

public class kontrol : MonoBehaviour
{

SerialPort stream = new SerialPort(); // Seri baglanti nesnesini olustur

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    public Text text9;
    public Text text10;
    public Text text11;
    public Text text12;

    public ArticulationBody baseJoint; // Temel eklem
    public ArticulationBody middleJoint; // Orta eklem
    public ArticulationBody basetopJoint; // Orta eklem
    public ArticulationBody endEffector;
    public ArticulationBody endEffector2; // Uç nokta

    public Slider baseSlider; // Genel dönüşü ayarlayan slider
    public Slider armSlider; // Kolun kendiyle yaptığı açıyı ayarlayan slider
    public Slider endEffectorSlider; // Kolun ucundaki tutucu kısmın açıklığını ayarlayan slider
    public Slider basetopSlider;

    public float rotationSpeed = 500f; // Dönme hızı

ArticulationDrive baseDrive;
ArticulationDrive middleDrive;
ArticulationDrive endEffectorDrive;
ArticulationDrive endEffector2Drive;
ArticulationDrive basetopDrive;

    void Start()
    {
        PlayerPrefs.SetString("COMPort","COM1");
        stream.Close();
        stream.BaudRate = 9600;
        stream.PortName = PlayerPrefs.GetString("COMPort");
       // Baglantibaslat();
    }

        public void Baglantibaslat(){
        try
        {
        stream.Parity = Parity.None;
        stream.DataBits = 8;
        stream.StopBits = StopBits.One;
        stream.Handshake = Handshake.None;
        stream.ReadTimeout = 1000;
        stream.WriteTimeout = 100;
        stream.PortName = PlayerPrefs.GetString("COMPort"); //!! port butona bastığında da yenilenmeli
        Debug.Log("Bağlanılan COM Port: " + stream.PortName);
        Debug.Log("bağlantı bu portta baslatiliyor" + PlayerPrefs.GetString("COMPort"));
        stream.Open();
        }catch (System.Exception e)
        {
            Debug.LogError("Seri baglanti acilamadi: " + e.Message);
        }
        }

    void Update()
    {
        float move1 = PlayerPrefs.GetFloat("move1");
        float move2 = PlayerPrefs.GetFloat("move2");
        float move3 = PlayerPrefs.GetFloat("move3");
        // Temel eklemi döndür
        baseDrive = baseJoint.xDrive;
        //baseDrive.target = baseSlider.value * rotationSpeed;
        baseDrive.target = move1 * rotationSpeed;
        baseDrive.targetVelocity = baseDrive.target/2;
        baseJoint.xDrive = baseDrive;

        basetopDrive = basetopJoint.xDrive;
        basetopDrive.target = move3 * rotationSpeed;
        basetopDrive.targetVelocity = basetopDrive.target/2;
        basetopJoint.xDrive = basetopDrive;

        // Orta eklemi döndür
        middleDrive = middleJoint.xDrive;
        //middleDrive.target = armSlider.value * rotationSpeed;
        middleDrive.target = move2 * rotationSpeed;
        middleDrive.targetVelocity = middleDrive.target/2;
        middleJoint.xDrive = middleDrive;

        // Uç noktayı döndür
        endEffectorDrive = endEffector.zDrive;
        endEffectorDrive.target = endEffectorSlider.value * rotationSpeed;
        endEffectorDrive.targetVelocity = endEffectorDrive.target/2;
        endEffector.zDrive = endEffectorDrive;

        endEffector2Drive = endEffector2.xDrive;
        endEffector2Drive.target = -endEffectorSlider.value * rotationSpeed;
        endEffector2Drive.targetVelocity = endEffector2Drive.target/2;
        endEffector2.xDrive = endEffector2Drive;

        text1.text = baseSlider.value.ToString();
        text2.text = baseDrive.target.ToString();
        text3.text = baseDrive.targetVelocity.ToString();

        text4.text = armSlider.value.ToString();

        text5.text = middleDrive.target.ToString();
        text6.text = middleDrive.targetVelocity.ToString();

        text7.text = endEffectorSlider.value.ToString();
        text8.text = endEffectorDrive.target.ToString();
        text9.text = endEffectorDrive.targetVelocity.ToString();

        text10.text = basetopSlider.value.ToString();
        text11.text = basetopDrive.target.ToString();
        text12.text = basetopDrive.targetVelocity.ToString();

       // stream.Write("M1");
       // stream.Write(baseDrive.target.ToString());
       // stream.Write("M2");
       // stream.Write(middleDrive.target.ToString());
       // stream.Write("M3");
       // stream.Write(endEffectorDrive.target.ToString());
       // stream.Write("M4");
       // stream.Write(basetopDrive.target.ToString());
    }

public void resetbutton ()
{
    baseSlider.value = 0;
    baseDrive.target = 0;
}

public void resetbutton2 ()
{
    armSlider.value = 0;
    middleDrive.target = 0;
}
public void resetbutton3 ()
{
    endEffectorSlider.value = 0;
    endEffectorDrive.target = 0;
}

public void resetbutton4 ()
{
    basetopSlider.value = 0;
    basetopDrive.target = 0;
}

public void testbuttoneksi ()
{
//stream.Write("A");
}
public void testbuttonarti ()
{
//stream.Write("B");
}
    
    void OnDestroy()
    {
      //  stream.Close(); // Uygulama kapandığında seri bağlantıyı kapat
    }

}
