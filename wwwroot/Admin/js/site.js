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

