import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';

function Dishes({ ingredient }) {
    const [post, setPost] = useState([]);

    useEffect(() => {
        if (ingredient) {
            axios.get("http://192.168.1.106:5003/Food?ingredient=" + ingredient).then((data) => {
                console.log(data);
                setPost(data?.data);
            });
        }
    }, [ingredient]);

    return (
        <>
            {post.map((item, i) => {
                return (
                    <div key={i}>
                        <p>{item?.name} -<span className='rating'> {item?.rating}&#11088;</span></p>
                    </div>
                );
            })}
        </>
    );
}

export default Dishes;
