using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCashed2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private List<int> sequence1 = new List<int>();
    private List<int> sequence2 = new List<int>();
    private bool isRecording = false;
    private bool isPlaying = false;
    private int currentIndex = 0;
    private Animator animator;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Awake()
    {
        animator = GetComponent<Animator>();
        // 初期位置と回転を保存
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        // TMProテキストフィールドを初期化
        GameObject.Find("routineValue").GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    IEnumerator PlayAnimationSequence()
    {
        while (isPlaying)
        {
            if (sequence2.Count > 0)
            {
                // 現在の値に基づいてアニメーションを再生
                int currentValue = sequence2[currentIndex];
                
                // すべてのアニメーションをfalseに設定
                animator.SetBool("Basic", false);
                animator.SetBool("RightT", false);
                animator.SetBool("SelfRightT", false);

                // 対応するアニメーションを再生
                switch (currentValue)
                {
                    case 1:
                        animator.SetBool("Basic", true);
                        GameObject.Find("techValue").GetComponent<TMPro.TextMeshProUGUI>().text = "1.BasicStep";
                        // アニメーションの完了を待つ（4秒待機）
                yield return new WaitForSeconds(4f);
                        break;
                    case 2:
                        animator.SetBool("RightT", true);
                        GameObject.Find("techValue").GetComponent<TMPro.TextMeshProUGUI>().text = "2.RightTurn";
                        // アニメーションの完了を待つ（4秒待機）
                yield return new WaitForSeconds(4f);
                        break;
                    case 3:
                        animator.SetBool("SelfRightT", true);
                        GameObject.Find("techValue").GetComponent<TMPro.TextMeshProUGUI>().text = "3.SelfRightTurn";
                        // アニメーションの完了を待つ（4秒待機）
                yield return new WaitForSeconds(4f);
                        break;
                }

                // アニメーションの完了を待つ（4秒待機）
                //yield return new WaitForSeconds(4f);

                // 次のインデックスに進む
                currentIndex = (currentIndex + 1) % sequence2.Count;
                
                // シーケンスの最後に到達したら初期位置に戻す
                if (currentIndex == 0)
                {
                    transform.position = initialPosition;
                    transform.rotation = initialRotation;
                }
            }
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRecording /*&& !isPlaying*/)
            {
                // 記録開始
                isRecording = true;
                sequence1.Clear();
                Debug.Log("Recording started");
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && isRecording && sequence1.Count > 0)
        {
            // 記録終了、再生開始
            isRecording = false;
            isPlaying = true;
            currentIndex = 0;
            
            // 記録された配列を表示
            string sequenceStr = string.Join(":", sequence1);
            Debug.Log("Recorded sequence: " + sequenceStr);
            // TMProのテキストフィールドにも配列の内容を表示
            GameObject.Find("routineValue").GetComponent<TMPro.TextMeshProUGUI>().text = sequenceStr;
            
            // sequence1をsequence2にコピーしてsequence1をクリア
            sequence2.Clear();
            sequence2 = new List<int>(sequence1);
            sequence1.Clear();
            
            // アニメーション再生開始
            StartCoroutine(PlayAnimationSequence());
        }

        // 記録中の数字キー入力処理
        if (isRecording)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                sequence1.Add(1);
                Debug.Log("Added 1 to sequence");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                sequence1.Add(2);
                Debug.Log("Added 2 to sequence");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                sequence1.Add(3);
                Debug.Log("Added 3 to sequence");
            }
        }
    }


}
