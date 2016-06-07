function buildTreeFromArray(a) {
	return $.ajax({
    		type: "POST",
    		data: JSON.stringify(a),
    		contentType: "application/json",
    		url:"http://localhost:4664/api/bstree"
    	});
}