# File Monitor

相關資訊定義在 defalut_config.xml 之中，請複製一份病重新命名為config.xml 放到執行程式的(.exe) 同層目錄夾，程式執行時即會讀取設定檔的內容進行運作。

<b>defalut_config.xml</b>

    <config>
        <mail_server_config>
            <host>smtp.gmail.com</host>
            <port>25</port>
            <enableSsl>1</enableSsl>
        </mail_server_config>
        <setting>
            <is_show_all>0</is_show_all>
        </setting>
        <symbole>
            <add>[Add]</add>
            <change>[Change]</change>
            <delete>[Delete]</delete>
            <normal>[Normal]</normal>
        </symbole>
        <mail_server>
            <mail_topic>信件主旨</mail_topic>
            <mail_account>ACCOUNT</mail_account>
            <mail_password>PASSWORD</mail_password>
            <mail_address>SenderMailAddress</mail_address>

            <TO>jmoriarty3533@gmail.com</TO>
            <CC>workfile975@gmail.com</CC>
            <BCC></BCC>
        </mail_server>
        <monitor>
            <check>check_files</check>
            <ignore>check_files\gaag</ignore>
            <ignore>check_files\haha</ignore>
        </monitor>
    </config>

* mail_server_config 
    * host : mail 服務的主機
    * port : mail server 的 port 號(預設為25)
    * enableSsl : 是否啟用ssl
        * 1 代表啟用
        * 0 代表不啟用
* mail_server
    * mail_topic : 信件主旨
    * mail_account : 帳號
    * mail_password : 密碼
    * mail_address : 由哪個信件地址發出信件
    * TO : 收信的信箱
    * CC : 信件副本
    * BCC : 密件副本
* monitor
    * check : 要檢查的 <b>目錄夾/檔案</b>
    * ignore : 略過不檢查的 <b>目錄夾/檔案</b>

* symbole : 檢查結果符號設定
    * add : 有新檔案
    * change : 檔案被更動
    * delete : 檔案被刪除
    * normal : 檔案沒有任何改變

* setting>
    * is_show_all : 顯示資訊時是否包含normal
        * 1 : 包含
        * 0 : 不包含

## 執行程式

程式目錄範例如下 :

![image](/docs/folder_view.PNG)

程式(File Monitor.exe)執行時會讀取 config.xml 的設定建立所有要檢查的檔案索引，建立完成後會產生 first_log.csv (隱藏檔案).

之後每次執行都會檢查目錄夾所有檔案與 first_log.csv 的紀錄的差異，寄送信件給目標網址.

若是要重新產生檔案索引，請直接刪除 first_log.csv 後重新執行 File Monitor.exe 即可.
