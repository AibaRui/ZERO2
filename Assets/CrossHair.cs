using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\��������
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
        // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Z ���W���J�����Ɠ����ɂȂ��Ă���̂ŁA���Z�b�g����

        mousePosition.z = 0;
        this.transform.position = mousePosition;


    }
}
