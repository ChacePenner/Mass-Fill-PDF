# **What is Mass Fill PDF?**

![image](https://github.com/user-attachments/assets/82788b33-6152-4242-98e2-e4b792d89d51)


Mass Fill PDF is an application that allows the user to quickly fill out multiple PDF form fields. 
The user can select one or more PDFs for upload and the application will automatically generate a table based on the form fields present in the PDFs. 
The heading of each table's column will reflect the names of the form field.

After filling out all the fields, the user can select the Fill PDF(s) button and one PDF will be generated and saved for each PDF uploaded and for each row of data.
For example, uploading one PDF and generating 5 rows of data will result in 5 unique PDFs.
By default the saved PDFs will append an incrementing number starting from 1 at the end of the file name. For example, example1.pdf, example2.pdf, and so on.
The user may alternatively choose to have the data from a specific column appended to the end of the PDF.

For example, if a column header is labeled "Student Name" and the PDF is named StudentLetter.pdf, the generated PDFs may look something like: StudentLetterJohnJones.pdf, StudentLetterRebeccaBlack.pdf, StudentLetterChacePenner.pdf, StudentLetterTomHolland.pdf, and StudentLetterZendayaColeman.pdf.

# **Unique Uses**

The main benefit of the application is filling out multiple forms that use the same form fields.
For example, in Kansas, it is required by law for teachers to send home letters to parents of ESOL students in both English and the parents' native languages.
Mass Fill PDF would allow the user to upload both a ParentLetterEnglish.pdf and a ParentLetterSpanish.pdf and fill out both forms simultaneously for as many students as needed.
In this scenario, all PDFs require the same information: Current Date, Student Name, School District, Contact Person Name, and Contact Person Phone Number.

If the user creates the same form fields on both PDFs and uses the same names for each relevant field, the application will only require the user to enter each set of information once in total rather than once for each PDF.
This is because the application assumes that any form fields with the same names will use the same data.

![image](https://github.com/user-attachments/assets/1f4894c6-ddd2-4c01-9084-fa7e40b72fa3)


![image](https://github.com/user-attachments/assets/293d82ca-18bf-4b0d-b32f-b5dff2aca056)


![image](https://github.com/user-attachments/assets/8b3b48e5-fff5-483c-aa92-2d6dfa011a9f)



In the scenario above, 10 PDfs will be generated in total. One for each student in English and one for each student in Spanish.

![image](https://github.com/user-attachments/assets/83a73905-2235-486c-823b-63bad418bbb4)


The following two images show a snippet of what the generated PDFs would look like for Student 1. 

![image](https://github.com/user-attachments/assets/fcb37455-e858-4f7d-ae22-553ab4d33971)



![image](https://github.com/user-attachments/assets/989c3927-98c0-400e-b561-9774ce234752)




# **Supported Features**

Any data already entered into a form field before uploading the PDF to the application will be automatically generated when the table is created.
This can save the user from having to repeatedly enter information that is present across all PDFs. 
For example, changing the Current Data before uploading the PDF will ensure all rows have the same data at the start.
This feature also supports checkboxes. Checkboxes are by default left unchecked, but if a checkbox is checked before the PDF is uploaded, it will generate checked.

Currently, the application supports PDFs with text fields, textareas, and checkboxes.

Hover over each button for a tooltip on what it does.

![image](https://github.com/user-attachments/assets/51151197-9c37-4996-9dd0-b4d14d90da83)


# **How do I generate a PDF with form fields?**

If you do not have Adobe Acrobat, you can use a website such as https://www.sejda.com/pdf-forms
This is the one used in the testing of this application.
You can upload any pdf and add text fields, textareas, and checkboxes.

![image](https://github.com/user-attachments/assets/9f276164-34d9-405a-96d3-b4f8cdf3b018)

![image](https://github.com/user-attachments/assets/3a56102d-f317-429e-8190-367d9ebfc47f)

**It is important to note** that the Field name you choose is the column name generated when uploading the PDF, so choose a name that identifies what data to input.
Also note that if you choose to upload multiple PDFs that require the same data, such as in the English/Spanish example above, you should make sure that each relevant field uses the same name.
For example, having Student Name be the name of the text field to enter a student's name on the English PDF but using Nombre del estudiante as the name on the Spanish PDf will generate two columns, one for each name.
Alternatively, if you using Student Name as the name for both PDFs, only one column will be generated but both PDFs will fill their respetive form from the same column, meaning the user does not have to enter each student's name twice.


# **PDFs to Test**

If you are interested in testing the program, here are some PDFs will form fields already added.
By default, the form fields do not contain any data. Experiment with adding data to see how the application pre-fills the fields for you.

[ParentNotificationLetterSpanish.pdf](https://github.com/user-attachments/files/19950122/ParentNotificationLetterSpanish.pdf)
[ParentNotificationLetterEnglish.pdf](https://github.com/user-attachments/files/19950121/ParentNotificationLetterEnglish.pdf)
