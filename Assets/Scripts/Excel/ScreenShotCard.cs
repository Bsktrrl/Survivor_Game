using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotCard : Singleton<ScreenShotCard>
{
    [SerializeField] bool isScreenShooting;


    //--------------------


    private void Update()
    {
        ActivateScreenShoot();
    }


    //--------------------


    void ActivateScreenShoot()
    {
        if (!Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && !isScreenShooting)
        {
            StartCoroutine(ScreenShot_OneCard(0.01f));
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && !isScreenShooting)
        {
            if (ReadExcelFile.Instance.newDataObjectList.dataObjectList.Length > 0)
            {
                StartCoroutine(ScreenShot_16Cards(0.01f));
            }
        }
    }
    IEnumerator ScreenShot_OneCard(float waitTime)
    {
        isScreenShooting = true;

        for (int i = 0; i < ReadExcelFile.Instance.newDataObjectList.dataObjectList.Length; i++)
        {
            ControlPanel.Instance.SetDataObjectActive(i + 1);

            yield return new WaitForSeconds(waitTime);

            TakePicture(ReadExcelFile.Instance.newDataObjectList.dataObjectList[ControlPanel.Instance.activeCard].fullName + ".jpg");

            yield return new WaitForSeconds(waitTime);
        }

        isScreenShooting = false;
    }
    IEnumerator ScreenShot_16Cards(float waitTime)
    {
        isScreenShooting = true;
        int counterForImageName = 0;

        for (int i = 0; i < ReadExcelFile.Instance.newDataObjectList.dataObjectList.Length; i += 8)
        {
            print("Round: " + (counterForImageName + 1));

            counterForImageName++;

            DisplayActiveCard.Instance.SetDisplay_8(i);

            yield return new WaitForSeconds(waitTime);

            TakePicture("Card Sheet_" + counterForImageName + ".jpg");

            yield return new WaitForSeconds(waitTime);
        }

        isScreenShooting = false;
    }
    void TakePicture(string imageName)
    {
        ScreenCapture.CaptureScreenshot(imageName);
    }
}
