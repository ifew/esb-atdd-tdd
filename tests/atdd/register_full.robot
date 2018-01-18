*** Settings ***
Library    Selenium2Library
#Test Teardown   Close Browser

*** Variables ***
${BROWSER}    chrome
${URL}  http://localhost:5000

*** Test Cases ***
การลงทะเบียนใช้ umayplus+ ได้สำเร็จ Odterm เท่ากับ 0
    กรอกข้อมูลลูกค้า    6273885053341539    3100505143401    01/01/2530
    แสดงข้อมูลลูกค้า    6273885053341539    3100505143401    01/01/2530    092224955
    ใส่ OTP ยืนยันตัวตน    6273885053341539    3100505143401    01/01/2530    092224955    545112
    ตั้ง username และ password    YAYA    yAyA1234    yAyA1234
    แสดงข้อความ success

การลงทะเบียนใช้ umayplus+ ได้สำเร็จ Odterm เท่ากับ 1
    กรอกข้อมูลลูกค้า    6273885056772172    3100505143555    28/02/2535
    แสดงข้อมูลลูกค้า    6273885056772172    3100505143555    28/02/2535    0819425721
    ใส่ OTP ยืนยันตัวตน    6273885056772172    3100505143555    28/02/2535    0819425721    147537
    ตั้ง username และ password    NADECH    105NaNaDe    y105NaNaDe

การลงทะเบียนใช้ umayplus+ ได้สำเร็จ Odterm เท่ากับ 2
    กรอกข้อมูลลูกค้า    6273885044701551    3100505154214    15/07/2528
    แสดงข้อมูลลูกค้า    6273885044701551    3100505154214    15/07/2528    0817741524
    ใส่ OTP ยืนยันตัวตน    6273885044701551    3100505143555    15/07/2528    0817741524    230159
    ตั้ง username และ password    MARKIE    Mar12Kie34    Mar12Kie34
    แสดงข้อความ success

*** Keywords ***
กรอกข้อมูลลูกค้า
    [Arguments]    ${CardNo}    ${CardID}    ${Date_Day}
    Open Browser    ${URL}    ${BROWSER}
    input text      txt_CardNo    ${CardNo}
    input text    txt_CardID    ${CardID}
    input text    txt_BirthDate    ${Date_Day}
    Submit Form

แสดงข้อมูลลูกค้า
    [Arguments]    ${CardNo}    ${CardID}    ${Date_Day}    ${MobileNo}
    Page Should Contain Textfield    txt_CardNo    ${CardNo}
    Page Should Contain Textfield    txt_CardID    ${CardID}
    Page Should Contain Textfield    txt_BirthDate    ${Date_Day}
    Page Should Contain Textfield    txt_MobileNo   ${MobileNo}
    Submit Form

ใส่ OTP ยืนยันตัวตน
    [Arguments]    ${CardNo}    ${CardID}    ${Date_Day}    ${MobileNo}    ${OTPcode}
    Page Should Contain Textfield    txt_CardNo    ${CardNo}
    Page Should Contain Textfield    txt_CardID    ${CardID}
    Page Should Contain Textfield    txt_BirthDate    ${Date_Day}
    Page Should Contain Textfield    txt_MobileNo    ${MobileNo}
    Input text    txt_OTP    ${OTPcode}
    Submit Form

ตั้ง Username และ Password
    [Arguments]    ${Username_reg}    ${Password_reg}    ${Password_cfm}
    input text    txt_Username    ${Username_reg}
    input text    txt_Password    ${Password_reg}
    input text    txt_PasswordCFM    ${Password_cfm}\
    Submit Form

แสดงข้อความ success
    Wait Until Page Contains    ขอบคุณค่ะ ท่านได้ลงทะเบียน Umayplus เรียบร้อยแล้วค่ะ