*** Settings ***
Library    Selenium2Library
Test Teardown   Close Browser

*** Variables ***
${BROWSER}    chrome
${URL}  http://localhost:5000

*** Test Cases ***
การลงทะเบียนใช้ umayplus+ ได้สำเร็จ Odterm เท่ากับ 0
    กรอกข้อมูลลูกค้า    6273885053341539    3100505143401    01/01/2530     092224955
    แสดงข้อมูลลูกค้า    6273885053341539    3100505143401    01/01/2530    092224955
    แสดงข้อความ success

*** Keywords ***
กรอกข้อมูลลูกค้า
    [Arguments]    ${CardNo}    ${CardID}    ${Date_Day}    ${MobileNo}
    Open Browser    ${URL}    ${BROWSER}
    input text    txt_CardNo    ${CardNo}
    input text    txt_CardID    ${CardID}
    input text    txt_BirthDate    ${Date_Day}
    input text    txt_MobileNo    ${MobileNo}
    Submit Form

แสดงข้อมูลลูกค้า
    [Arguments]    ${CardNo}    ${CardID}    ${Date_Day}    ${MobileNo}
    Wait Until Page Contains    ${CardNo}
    Wait Until Page Contains    ${CardID}
    Wait Until Page Contains    ${Date_Day}
    Wait Until Page Contains   ${MobileNo}
    Submit Form

แสดงข้อความ success
    Wait Until Page Contains    ขอบคุณค่ะ ท่านได้ลงทะเบียน Umayplus เรียบร้อยแล้วค่ะ