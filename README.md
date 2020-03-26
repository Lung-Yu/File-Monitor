# File Monitor

相關資訊定義在 defalut_config.xml 之中，請複製一份病重新命名為config.xml 放到執行程式的(.exe) 同層目錄夾，程式執行時即會讀取設定檔的內容進行運作。

<b>defalut_config.xml</b>

    <mail_server_config>
            <host>smtp.gmail.com</host>
            <port>25</port>
            <enableSsl>1</enableSsl>
    </mail_server_config>
    <mail_server>
        <mail_topic>信件主旨</mail_topic>
        <mail_account>ACCOUNT</mail_account>
        <mail_password>PASSWORD</mail_password>
        <mail_address>SenderMailAddress</mail_address>

        <TO>to@gmail.com</TO>
        <CC>cc@gmail.com</CC>
        <BCC>bcc@gmail.com</BCC>
    </mail_server>
    <monitor>
        <check>checkFolder</check>
        <ignore>ignoreFolder</ignore>
        <ignore>ignoreFile</ignore>
    </monitor>