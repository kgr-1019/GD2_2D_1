using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    [SerializeField] private float speed;
    private float targetSize = 3f;
    private float currentSize = 0f;
    private bool isExpanding = true;// �T�C�Y���g�咆���ǂ���
    private float timer = 0f;// �ڕW�T�C�Y�ɒB������J�n����^�C�}�[
    private bool timerActive = false;// �^�C�}�[���A�N�e�B�u���ǂ���
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (isExpanding)
        {
            if (currentSize < targetSize)
            {
                currentSize += speed * Time.deltaTime;
                transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            }
            else
            {
                isExpanding = false;// �T�C�Y���ڕW�l�ɒB������g����~
                timerActive = true;// �^�C�}�[���A�N�e�B�u��
            }
        }
        else
        {
            // �O�b�Ԑ����Ă�Ƃ�
            if (timerActive)
            {
                timer += Time.deltaTime;

                // �^�C�}�[���O�b�𒴂������A�N�e�B�u�ɂ���
                if (timer >= 3f)
                {
                    timerActive = false;
                }
            }
            else// �O�b�Ԑ����ĂȂ��Ƃ�
            {
                if (currentSize > 0f)
                {
                    currentSize -= speed * Time.deltaTime;
                    transform.localScale = new Vector3(currentSize, currentSize, currentSize);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void isGoal()
    {
        Debug.Log("Goal! ");       
    }
}
