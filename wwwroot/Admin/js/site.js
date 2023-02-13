var Categories = {
    GetAllCategories: function () {
        $.get('/Admin/Categories/List',
            function (data) {
                console.log(data);
               // $("#formContainer").html(data);
              
            });
                        
    },   
    ShowPopup: function (state) {
        if (state === "Add") {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Category Added Successfully',
                showConfirmButton: false,
                timer: 3000
            })
        }
        else {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Your Category has been Updated',
                showConfirmButton: false,
                timer: 3000
            })

        }
    },
    DeleteCategory: function (btn,categoryid) {
        bootbox.confirm('Are you sure ?',
            function (result) {
                if (result) {
                    $.post('/Admin/Categories/Delete?categoryid=' + categoryid,
                        function () {
                            Swal.fire(
                                'Good job!',
                                'Category Deleted Successfuly!',
                                'success'
                            )
                            var row = btn.parentNode.parentNode
                            console.log(row);            
                            row.classList.add("animate__animated animate__flash");

                            //row.ClassName +='animate__animated animate__flash';
                           
                            
                        });                
                 
                    
                }
            });               
    },
   

}
var Authors = {
    ShowPopup: function (state) {
        if (state === "Add") {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Category Added Successfully',
                showConfirmButton: false,
                timer: 3000
            })
        }
        else {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Your Category has been Updated',
                showConfirmButton: false,
                timer: 3000
            })

        }
    }
    , DeleteAuthor: function (btn, authorid) {
        bootbox.confirm('Are you sure ?',
            function (result) {
                if (result) {
                    $.post('/Admin/Authors/Delete?authorid=' + authorid,
                        function () {
                            Swal.fire(
                                'Good job!',
                                'Author Deleted Successfuly!',
                                'success'
                            )
                         

                        });


                }
            });
    },
}
$(document).ready(function () {
    //date calendar
    $('#datecalender').daterangepicker({
        singleDatePicker: true,
        "drops": "up",
        showDropdowns: true,


    })
    //select2
    $('.js-select').select2();
    $('.js-select').on('select2:select', function (e) {
        $('form').validate().element('#' + this.attr('id'))
    });

    //tinymce text editor


    tinymce.init({
        selector: '.js-tinymce',
        plugins: 'anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount checklist mediaembed casechange export formatpainter pageembed linkchecker a11ychecker tinymcespellchecker permanentpen powerpaste advtable advcode editimage tinycomments tableofcontents footnotes mergetags autocorrect typography inlinecss',
        toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table mergetags | addcomment showcomments | spellcheckdialog a11ycheck typography | align lineheight | checklist numlist bullist indent outdent | emoticons charmap | removeformat',
        tinycomments_mode: 'embedded',
    });

});
      
