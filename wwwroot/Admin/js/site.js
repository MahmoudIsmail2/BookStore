var Categories = {
    GetAllCategories: function () {
        $.ajax({
            url: "/Admin/Categories/List",
            success: function (data) {
                console.log(data);
                success(data);
                return data;
            },
            error: function () {

            },

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
    DeleteCategory: function (categoryid) {
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
                        });

                }
            });

    },

}

