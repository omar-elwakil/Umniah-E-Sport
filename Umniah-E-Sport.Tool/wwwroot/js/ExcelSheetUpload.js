function Upload() {
    var result = confirm("Are you sure that you want to upload that file ?");
    if (result == true) {
        //Reference the FileUpload element.
        var fileUpload = document.getElementById("fileUpload");

        //Validate whether File is valid Excel file.
        //var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$/;
        var regex = /([\s\S\W|_])+(.xls|.xlsx)$/;
        if (regex.test(fileUpload.value.toLowerCase())) {
            if (typeof (FileReader) != "undefined") {
                var reader = new FileReader();

                //For Browsers other than IE.
                if (reader.readAsBinaryString) {
                    reader.onload = function (e) {
                        ProcessExcel(e.target.result);
                    };
                    reader.readAsBinaryString(fileUpload.files[0]);
                } else {
                    //For IE Browser.
                    reader.onload = function (e) {
                        var data = "";
                        var bytes = new Uint8Array(e.target.result);
                        for (var i = 0; i < bytes.byteLength; i++) {
                            data += String.fromCharCode(bytes[i]);
                        }
                        ProcessExcel(data);
                    };
                    reader.readAsArrayBuffer(fileUpload.files[0]);
                }
            } else {
                alert("This browser does not support HTML5.");
            }
        } else {
            alert("Please upload a valid Excel file.");
        }
    }
}
function ProcessExcel(data) {
    //Read the Excel File data.
    var workbook = XLSX.read(data, {
        type: 'binary'
    });

    //Fetch the name of First Sheet.
    var firstSheet = workbook.SheetNames[0];

    //Read all rows from First Sheet into an JSON array.
    var excelRows = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[firstSheet]);
    var data = new Array();
    excelRows.forEach(element => {
        data.push(element);
    });
    //var Message = document.getElementById("Message").value;
    //var BName = document.getElementById("BulkName").value;
    var form = $('#__AjaxAntiForgeryForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var dataa = {
        __RequestVerificationToken: token,
        dataList: data,
        check: checkB,
    };
   

    if (data.length > 1024) {
        alert("Please make number of Row less than 1024");
        location.reload(true);
        //var count = Math.ceil(data.length / 1024);
        //MoreThan1024Row(data, count, token, true);
    } else {
        $.ajax({
            //this url is come from each indx view
            url: url,
            dataType: 'Json',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: dataa,
            success: function (response) {
                if (response.success) {
                    UploadFile();
                } else {
                    alert(response.responseText);
                    //console.log(response.responseText);
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                //console.log(errorThrown);
                alert("Error : Something went wrong ... please check sheet headers name conventions or check for non valid data in the sheet");
            }
        });
    }

}
//function MoreThan1024Row(datas, count, token, checked) {
//    //debugger;
//    var counter = Math.ceil(datas.length / 1024) - count;
//    var start = counter * 1024;
//    var end = start + 1024;
//    var arr = datas.slice(start, end);
//    var dataa;
//    //if (urlFile == "Videos/UploadExcelSheetFile") {
//    //    dataa = {
//    //        __RequestVerificationToken: token,
//    //        dataList: arr,
//    //        check: checked
//    //    };
//    //} else {
//    //    dataa = {
//    //        __RequestVerificationToken: token,
//    //        dataList: arr,
//    //    };
//    //}

//    $.ajax({
//        //this url is come from each indx view
//        url: url,
//        dataType: 'Json',
//        type: 'post',
//        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
//        data: dataa,
//        success: function (response) {
//            if (response.success) {
//                count = count - 1;
//                if (count !== 0) {
//                    MoreThan1024Row(datas, count, token, false);
//                } else {
//                    UploadFile();
//                }
//            } else {
//                alert("Error! : data not upload");
//                console.log(response.responseText);
//            }

//        },
//        error: function (xhr, textStatus, errorThrown) {
//            console.log(errorThrown);
//            alert("Error: please check your data or upload again");
//        }
//    });
//}

//function checkselect() {
//    document.getElementById("warningError").style.color = "red";
//    document.getElementById("warningError").textContent = "please Select Video Type";
//}
//checkselect();

function check() {
    var uploadInput = document.getElementById("fileUpload").value;
    var login = document.getElementById("upload");
    if (!hasExtension(uploadInput, ['.xlsx', '.xls'])) {
        document.getElementById("warningError").style.color = "red";
        document.getElementById("warningError").textContent = "please upload sheet with .xls or .xlsx extension !!";
        login.disabled = true;
        login.style.cursor = 'not-allowed';
    }
    else {
        document.getElementById("warningError").textContent = "uploaded successfully";
        document.getElementById("warningError").style.color = "blue";
        login.disabled = (uploadInput.length == 0) ? true : false;

        login.style.cursor =
            (uploadInput.length == 0)
                ? 'not-allowed' : 'pointer';
    }
}
check();
function hasExtension(file, exts) {
    return (new RegExp('(' + exts.join('|').replace(/\./g, '\\.') + ')$')).test(file);
}

function UploadFile() {
    var fileUpload = $(".modal-body #fileUpload").get(0);
    var files = fileUpload.files;
    var data = new FormData();
    data.append(files[0].name, files[0]);
    $.ajax({
        type: "POST",
        url: urlFile,
        contentType: false,
        processData: false,
        data: data,
        async: false,
        success: function (response) {
            if (response.success) {
                alert(response.responseText);
                location.reload(true);
            } else {
                alert("Error: File Not Uploaded");
                //console.log(response.responseText);
            }

        },
        error: function (xhr, textStatus, errorThrown) {
            //console.log(errorThrown);
            alert("Error: Data uploaded to database successfully, but sheet file is not uploaded");
        }
    });
}